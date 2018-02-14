using MvvmCross.Core.ViewModels;
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
    }
}
