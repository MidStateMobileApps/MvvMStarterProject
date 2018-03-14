﻿using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectTemplate.Services
{
    public interface IListPopulatorService
    {
        MvxViewModel Parent { get; set; }
        List<string> GetAvailableCourses();

        string GetInformation(string title);

        string GetImage(string title);

        Task<List<MenuItem>> GetMenuItems();

    }
}
