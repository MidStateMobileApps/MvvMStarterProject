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
    public class ListPopulatorService : IListPopulatorService
    {
        public ListPopulatorService()
        {
            Courses = new List<string>()
            {
                "Object Oriented Programming II",
                "Intermediate Mobile Apps",
                "Written Communication",
                "Software Architecture"
            };
            Information = new List<string>()
            {
                "OOPII Filler",
                "Mobile Filler",
                "WritCom Filler",
                "Software Filler"
            };
            Images = new List<string>()
            {
                "starstroup",
                "jobs",
                "gaul",
                "noyce"
            };
        }

        List<string> Courses { get; set; }

        List<string> Information { get; set; }

        List<string> Images { get; set; }

        MainMenuViewModel thisParent { get; set; }

        public List<string> GetAvailableCourses()
        {
            return Courses;
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

        public async Task<string> GetClassDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = await webRequest.GetResponseAsync();

            var streamResp = response.GetResponseStream();

            if (streamResp.CanRead)
            {
                StreamReader reader = new StreamReader(streamResp);

                string words = reader.ReadToEnd();

                string noCommas = words.Replace(',',' ');

                return noCommas;
            }
            else
            {

                return string.Empty;
            }
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Courses = GetAvailableCourses();

            List<MenuItem> Items = Courses.Select(s => new MenuItem(s, this.thisParent)).ToList();

            foreach (var item in Items)
            {
                item.Description = await GetClassDescription();
            }

            return Items;
        }


        MvxViewModel IListPopulatorService.Parent { get { return thisParent; } set { thisParent = (MainMenuViewModel)value; } }
    }
}