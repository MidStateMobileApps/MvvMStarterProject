using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace NewProjectTemplate.Services
{
    class ListPopulatorService : IListPopulatorService
    {
        MvxViewModel ThisParent { get; set; }
        public ListPopulatorService()
        {
        }

        MvxViewModel IListPopulatorService.Parent { get { return ThisParent; } set { ThisParent = value; } }

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
    }
}
