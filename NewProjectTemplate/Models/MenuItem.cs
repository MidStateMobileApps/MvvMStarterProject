using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItem : MvxViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        private string _info;
        private string _myDrawable;

        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        public string MyDrawable
        {
            get { return _myDrawable; }
            set
            {
                _myDrawable = value;
                RaisePropertyChanged(() => MyDrawable);
            }
        }

        MainMenuViewModel Parent { get; set; }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Title = title;
            Parent = parent;
            Info = "Tap here for more info";
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowTheMenuPick(this));
            ShowMoreInfo = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowMoreInfo(this));
            MyDrawable = "placeholder";
        }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowMoreInfo { get; set; }
    }
}