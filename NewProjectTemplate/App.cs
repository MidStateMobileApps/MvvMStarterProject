using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using NewProjectTemplate.Services;

namespace NewProjectTemplate
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            /*CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton(); */

            Mvx.RegisterType<IListPopulatorService, ListPopulatorService>();
            RegisterNavigationServiceAppStart<ViewModels.MainMenuViewModel>();
        }
    }
}
