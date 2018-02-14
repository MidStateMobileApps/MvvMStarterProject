using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Services;

namespace NewProjectTemplate.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IListPopulatorService _populatorService;
        private string _classList;
        public string ClassList
        {
            get { return _classList; }
            set { _classList = value; }
        }

        public MainViewModel(IListPopulatorService service)
        {
            _populatorService = service;
        }
        
        public override Task Initialize()
        {
            var classes = _populatorService.GetAvailableCourses();
            StringBuilder sb = new StringBuilder();
            foreach (string s in classes)
            {
                sb.Append($"{s} \n");
            }
            _classList = sb.ToString();
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