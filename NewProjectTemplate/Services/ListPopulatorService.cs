using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace NewProjectTemplate.Services
{
    public class ListPopulatorService : IListPopulatorService
    {
        public ListPopulatorService()
        {
        }

        MvxViewModel thisParent { get; set; }

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

        MvxViewModel IListPopulatorService.Parent { get { return thisParent; } set { thisParent = value; } }
    }
}
