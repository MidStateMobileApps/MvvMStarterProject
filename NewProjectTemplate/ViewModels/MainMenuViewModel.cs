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

        public MainMenuViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public void ShowTheMenuPicked(MenuItem item)
        {
            string sItem = JsonConvert.SerializeObject(item);
            Dictionary<string, string> pair = new Dictionary<string, string>()
            {
                { "MenuItem", sItem}
            };

            MvxBundle bundle = new MvxBundle(pair);

            ShowViewModel<MainViewModel>(bundle);
        }

        public void ShowMoreInfo(MenuItem item)
        {
            item.Info = populatorService.GetInformation(item.Title);
            item.MyDrawable = populatorService.GetImage(item.Title);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public override Task Initialize()
        {
            populatorService.Parent = this;


            return base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            MenuItems = new List<MenuItem>
            {
                new MenuItem("Object Oriented Programming II", this) {Description = "Tap for more info" },
                new MenuItem("Intermediate Mobile Apps", this) {Description = "Tap for more info" },
                new MenuItem("Written Communication", this) {Description = "Tap for more info" },
                new MenuItem("Software Architecture", this) {Description = "Tap for more info" }
            };
                
                
                //await populatorService.GetMenuItems();
         InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }
        
    }
}
