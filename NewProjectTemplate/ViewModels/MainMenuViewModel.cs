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

        public void ShowMoreInfo(MenuItem item)
        {
            item.Info = _populatorService.GetInformation(item.Title);
            item.MyDrawable = _populatorService.GetImage(item.Title);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public override async void Start()
        {
            base.Start();
           // MenuItems = await _populatorService.GetMenuItemsAsync();
           MenuItems = new List<MenuItem>()
            { new MenuItem("OOP II", this) {Description="Tap for more info"},
            new MenuItem("Intermediate Mobile Apps", this) {Description="Tap for more info"},
            new MenuItem("Software Architecture", this) {Description="Tap for more info"},
            new MenuItem("Written Communication", this) {Description="Tap for more info"}
           }; ///_populatorService.GetMenuItemsAsync();
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }
        public IMvxAsyncCommand ShowCommand { get; set; }
    }
}
