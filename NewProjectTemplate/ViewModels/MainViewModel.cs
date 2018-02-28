using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Models;
using NewProjectTemplate.Services;
using Newtonsoft.Json;

namespace NewProjectTemplate.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IListPopulatorService _populatorService;
        private string _classList;
        private MenuItems _menuItem;
        public string ClassList
        {
            get
            {
                return _classList;
            }
            set
            {
                _classList = value;
            }
        }

        public MainViewModel(IListPopulatorService service)
        {
            _populatorService = service;
        }
        
        public override Task Initialize()
        {

            var classes = _populatorService.GetAvailableCourses();
            StringBuilder sb = new StringBuilder();
            foreach(string s in classes)
            {
                sb.Append($"{s} \n");
            }
            // classes.Select(c => sb.Append($"{c} \n"));
            _classList = sb.ToString();
            return base.Initialize();
        }


        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var item = JsonConvert.DeserializeObject<MenuItems>(parameters.Data["MenuItem"]);
            _menuItem = new MenuItems(item.Title, null)
            {
                Description = item.Description,
                Title = item.Title
            };
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