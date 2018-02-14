﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace NewProjectTemplate.Services
{
    public class ListPopulatorService : IListPopulatorService
    {
        MvxViewModel Parent { get; set; }
        public ListPopulatorService()
        {
        }
        MvxViewModel IListPopulatorService.Parent { get { return Parent; } set { Parent = value; }

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

        List<string> IListPopulatorService.GetAvailableCourses()
        {
            throw new NotImplementedException();
        }
    }
}
