using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                "Let's make some apps bra!",
                "Talk about what you are doing (or write it)",
                "Do it right the first time"
            };
            Images = new List<string>()
            {
                "starstroup",
                "jobs",
                "gaul",
                "noyce"
            };
        }

        MvxViewModel IListPopulatorService.Parent { get { return Parent; } set { Parent = value as MainMenuViewModel; } }

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
        public async Task<string>GetClassDescription()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Host = "mstc.edu";

            string path = "http://www.wordgenerator.net/application/p.php?id=nouns&type=1";
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if ( response.IsSuccessStatusCode )
                {
                    var result = await response.Content.ReadAsStreamAsync();
                }
            }
            catch (System.Exception ex)
            {

            }
            

            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                WebResponse response = await webRequest.GetResponseAsync();
                var streamResp = response.GetResponseStream();

                if (streamResp.CanRead)
                {
                    StreamReader reader = new StreamReader(streamResp);
                    string words = reader.ReadToEnd();
                    string noCommas = words.Replace(',', ' ');
                    return noCommas;
                }
            }
            catch (System.Exception ex)
            {

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
