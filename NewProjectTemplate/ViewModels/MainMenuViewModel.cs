using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Models;
using NewProjectTemplate.Services;
using Newtonsoft.Json;
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
        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }
        //public IMvxAsyncCommand

        public MainMenuViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public override Task Initialize()
        {
            populatorService.Parent = this;

            return base.Initialize();
        }

        public void ShowTheMenuPick(MenuItem item)
        {
            string sItem = JsonConvert.SerializeObject(item);
            Dictionary<string, string> pair = new Dictionary<string, string>()
            {
                {"MenuItem", sItem }
            };
            MvxBundle bundle = new MvxBundle(pair);
            ShowViewModel<MainViewModel>(bundle);
        }

        public async override void Start()
        {
            base.Start();
            MenuItems = new List<MenuItem> { new MenuItem("Some class 1", this) { Description = "a description" }, new MenuItem("class 2", this) { Description = "second desc" } };
                //await populatorService.GetMenuItems();
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

    }
}
