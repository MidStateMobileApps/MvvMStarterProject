using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItem : MvxViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        MainMenuViewModel Parent { get; set; }

        private string info;

        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                SetProperty(ref info, value);
            }
        }

        private string myDrawable;

        public string MyDrawable
        {
            get
            {
                return myDrawable;
            }
            set
            {
                myDrawable = value;
                RaisePropertyChanged(() => MyDrawable);
            }
        }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Title = title;
            Parent = parent;
            Info = "Tap Here For More Info";
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowTheMenuPicked(this));
            ShowMoreInfo = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowMoreInfo(this));
            myDrawable = "placeholder";
        }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowMoreInfo { get; set; }
    }
}