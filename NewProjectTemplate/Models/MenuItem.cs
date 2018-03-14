﻿using MvvmCross.Core.ViewModels;
using NewProjectTemplate.ViewModels;
using Newtonsoft.Json;

namespace NewProjectTemplate.Models
{
    public class MenuItem : MvxViewModel
    {

        public string Title { get; set; }
        MainMenuViewModel Parent { get; set; }
        public string Description { get; set; }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        private string _myDrawable;
        public string MyDrawable
        {
            get { return _myDrawable; }
            set
            {
                _myDrawable = value;
                RaisePropertyChanged(() => MyDrawable);
            }
        }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Title = title;
            Parent = parent;
            Info = "Tap here for more info";
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => Parent.ShowTheMenuPick(this));
            ShowMoreInfo = new MvxCommand<MenuItem>((MenuItem obj) => Parent.ShowMoreInfo(this));
            _myDrawable = "placeholder";
        }
        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowMoreInfo { get; set; }
    }
}