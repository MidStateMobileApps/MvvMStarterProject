using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using NewProjectTemplate.ViewModels;

namespace NewProjectTemplate.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
