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
                "Written Communications",
                "Software Architecture"
            };
            return courses;
        }

        public async Task<string> GetClassDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = await webRequest.GetResponseAsync();
            var streamResponse = response.GetResponseStream();

            if (streamResponse.CanRead)
            {
                StreamReader reader = new StreamReader(streamResponse);
                string words = reader.ReadToEnd();
                string noCommas = words.Replace(",", " ");

                return noCommas;
            }
            else
            {
                return string.Empty;
            }
        }

        List<string> IListPopulatorService.GetAvailableCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Courses = GetAvailableCourses();
            List<MenuItem> items = Courses.Select(s => new MenuItem(s, Parent)).ToList();
            // ^^ Same as below
            // foreach (string c in Courses)
            // {
            //     var item = new MenuItem(c, Parent);
            // }
            foreach (var i in items)
            {
                i.Description = await GetClassDescription();
            }

            return items;
        }
    }
}
