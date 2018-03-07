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
        MainMenuViewModel Parent { get; set; }
        public ListPopulatorService()
        {
        }

        MvxViewModel IListPopulatorService.Parent { get { return Parent; } set { Parent = value as MainMenuViewModel; } }

        public List<string> GetAvailableCourses()
        {
            List<string> courses = new List<string>()
            {
                "Object Oriented Programming II",
                "Intermediate Mobile Apps",
                "Written Communication",
                "Software Architecture"
            };
            return courses;
        }

        public async Task<string>GetClassDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response =  await webRequest.GetResponseAsync();
            var streamResp = response.GetResponseStream();

            if ( streamResp.CanRead)
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
            List<MenuItem> items = Courses.Select(s => new MenuItem(s, Parent)).ToList();
            foreach ( var item in items)
            {
                item.Description = await GetClassDescription();
            }
            return items;
        }
    }
}
