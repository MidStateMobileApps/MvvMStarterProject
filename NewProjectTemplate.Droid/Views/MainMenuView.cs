using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using NewProjectTemplate.ViewModels;

namespace NewProjectTemplate.Droid.Views
{
    [Activity(Label = "Main Menu View")]
    public class MainMenuView : MvxActivity<MainMenuViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            try
            {
                SetContentView(Resource.Layout.MainMenuView);
            }
            catch(System.Exception ex)
            {
                string s = ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(s);
            }
        }

    }
}