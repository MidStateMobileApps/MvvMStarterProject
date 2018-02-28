using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItems
    {

        public string Title { get; set; }
        MainMenuViewModel Parent { get; set; }
        public string Description { get; set; }
        public MenuItems(string title, MainMenuViewModel parent)
        {
            Parent = parent;
            ShowCommand = new MvxCommand<MenuItems>((MenuItems obj) => Parent.ShowTheMenuPick(this));
        }
        [JsonIgnore]
        public IMvxCommand<MenuItems> ShowCommand { get; set; }
    }
}