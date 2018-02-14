using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectTemplate.Services
{
    public class ListPopulatorService : IlistPopulatorService
    {
        MvxViewModel Parent { get; set; }
        public ListPopulatorService()
        { }
        MvxViewModel IlistPopulatorService.Parent {get { return Parent; } set { Parent = value; } }
            

        public List<string> GetAvailableCourses()
        {
            List<string> courses = new List<string>()
            {
                "Object Orientated Programing II",
                "Intermediate Mobile Apps",
                "Ethics" ,
                "Software Architecture"
            };
            return courses;
        }
    }
}
