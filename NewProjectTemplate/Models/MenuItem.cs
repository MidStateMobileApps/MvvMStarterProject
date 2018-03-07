using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItem
    {

        public string Title { get; set; }
        MainMenuViewModel Parent { get; set; }
        public string Description { get; set; }
        public MenuItem(string title, MainMenuViewModel parent)
        {
            Title = title;
            Parent = parent;
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => Parent.ShowTheMenuPick(this));
        }
        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }
    }
}