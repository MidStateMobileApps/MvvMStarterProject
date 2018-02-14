using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Services;

namespace NewProjectTemplate.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IListPopulatorService populatorService;
        private string classList;
        public string ClassList
        {
            get
            {
                return classList;
            }
            set
            {
                classList = value;
            }
        }

        public MainViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }
        
        public override Task Initialize()
        {
            var classes = populatorService.GetAvailableCourses();
            StringBuilder sb = new StringBuilder();
            foreach(string s in classes)
            {
                sb.Append($"{s} \n");
            }
            // classes.Select(c => sb.Append($"{c} \n"));
            classList = sb.ToString();
            return base.Initialize();
        }
        
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}