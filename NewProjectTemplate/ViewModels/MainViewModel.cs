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
        private MenuItem _menuItem;
        private string _title;
        private string _description;
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
            return base.Initialize();
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var item = JsonConvert.DeserializeObject<MenuItem>(parameters.Data["MenuItem"]);
            _menuItem = new MenuItem(item.Title, null)
            {
                Description = item.Description,
                Title = item.Title
            };

            _title = _menuItem.Title;
            _description = _menuItem.Description;
        }
        
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Title = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            private set { SetProperty(ref _text, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}