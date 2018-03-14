using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Models;
using NewProjectTemplate.ViewModels;

namespace NewProjectTemplate.Services
{
    class ListPopulatorService : IListPopulatorService
    {
        MainMenuViewModel thisParent { get; set; }
        List<string> Courses { get; set; }
        List<string> Information { get; set; }
        List<string> Images { get; set; }

        public ListPopulatorService()
        {
            Courses = new List<string>()
            {
                "OOP II",
                "Intermediate Mobile Apps",
                "Written Communication",
                "Software Architecture"
            };

            Information = new List<string>()
            {
                "Learn how to really do stuff well",
                "Let's make some apple apps",
                "You write a bunch, hand cramp",
                "Learn how agile works"
            };

            Images = new List<string>()
            {
                "starstroup",
                "jobs",
                "gaul",
                "noyce"
            };
        }

        MvxViewModel IListPopulatorService.Parent
        {
            get
            {
                return thisParent;
            }
            set
            {
                thisParent = (MainMenuViewModel)value;
            }
        }

        public List<string>  GetAvailableCourses()
        {
            return Courses;
        }

        public async Task<string> GetClassDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = await webRequest.GetResponseAsync();
            var streamResponse = response.GetResponseStream();

            if(streamResponse.CanRead)
            {
                StreamReader reader = new StreamReader(streamResponse);
                string words = reader.ReadToEnd();
                string noCommas = words.Replace(',', ' ');
                return noCommas;
            }
            return string.Empty;
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Courses = GetAvailableCourses();
            List<MenuItem> items = Courses.Select(s => new MenuItem(s, thisParent)).ToList();
            foreach (var item in items)
            {
                item.Description = await GetClassDescription();
            }
            return items;
        }

        public string GetInformation(string title)
        {
            int ix = Courses.IndexOf(title);
            if (ix >= 0) return Information[ix];
            return string.Empty;
        }

        public string GetImage(string title)
        {
            int ix = Courses.IndexOf(title);
            if (ix >= 0) return Images[ix];
            return string.Empty;
        }
    }
}
