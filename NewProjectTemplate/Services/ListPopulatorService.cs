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
        MainMenuViewModel ThisParent { get; set; }
        List<string> Courses{ get; set; }
        List<string> Information { get; set; }
        List<string> Images { get; set; }
        public ListPopulatorService()
        {
            Courses = new List<string>()
            {
                "Web Programming I",
                "Systems Implementation",
                "Intermediate Mobile Apps"
            };

            Information = new List<string>()
            {
                "Learn about PHP and MySQL",
                "Team based class with real-world development",
                "More advanced learning about mobile app development"
            };

            Images = new List<string>()
            {
                "gaul",
                "jobs",
                "noyce"
            };
        }

        MvxViewModel IListPopulatorService.Parent { get { return ThisParent; } set { ThisParent = (MainMenuViewModel)value; } }

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
                string noCommas = words.Replace(',', ' ');
                return noCommas;
            }
            return string.Empty;

        }

        public async Task<List<MenuItem>> GetMenuItemsAsync()
        {
            List<string> Courses = GetAvailableCourses();
            List<MenuItem> items = Courses.Select(s => new MenuItem(s, ThisParent)).ToList();
            foreach(var item in items)
            {
                item.Description = await GetClassDescription();
            }
            return items;
        }

    }
}
