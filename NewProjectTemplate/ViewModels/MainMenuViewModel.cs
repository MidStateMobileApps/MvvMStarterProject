using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectTemplate.ViewModels
{
    class MainMenuViewModel : MvxViewModel
    {
        IListPopulatorService _populatorService;
        public MainMenuViewModel(IListPopulatorService service)
        {
            _populatorService = service;
        }
        public override Task Initialize()
        {
            _populatorService.Parent = this;
            return base.Initialize();
        }
    }
}
