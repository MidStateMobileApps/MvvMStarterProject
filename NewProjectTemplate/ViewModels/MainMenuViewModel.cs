using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectTemplate.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        IListPopulatorService populatorService;

        public MainMenuViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public override Task Initialize()
        {
            populatorService.Parent = this;


            return base.Initialize();
        }
    }
}
