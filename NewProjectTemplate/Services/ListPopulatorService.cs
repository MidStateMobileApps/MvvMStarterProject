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
        public ListPopulatorService()
        {
        }

        MvxViewModel IListPopulatorService.Parent { get { return ThisParent; } set { ThisParent = (MainMenuViewModel)value; } }

        public List<string> GetAvailableCourses()
        {
            List<string> courses = new List<string>()
            {
                "Web Programming I",
                "Intermediate Mobile Apps",
                "Systems Implementation"
            };

            return courses;
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

        public async Task<List<MenuItems>> GetMenuItemsAsync()
        {
            List<string> Courses = GetAvailableCourses();
            List<MenuItems> items = Courses.Select(s => new MenuItems(s, ThisParent)).ToList();
            foreach(var item in items)
            {
                item.Description = await GetClassDescription();
            }
            return items;
        }
    }
}
