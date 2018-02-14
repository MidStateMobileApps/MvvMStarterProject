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
        MvxViewModel thisParent { get; set; }

        public ListPopulatorService()
        {

        }

        MvxViewModel IListPopulatorService.Parent
        {
            get
            {
                return thisParent;
            }
            set
            {
                thisParent = value;
            }
        }

        public List<string>  GetAvailableCourses()
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
    }
}
