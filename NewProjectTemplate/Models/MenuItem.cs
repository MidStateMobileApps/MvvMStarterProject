using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        MainMenuViewModel Parent { get; set; }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Parent = parent;
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowTheMenuPicked(this));
        }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }
    }
}