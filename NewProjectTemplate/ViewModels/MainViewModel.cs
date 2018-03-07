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
        private IListPopulatorService populatorService;

        private string classList;
        private string title;
        private string description;

        private MenuItem menuItem;

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
            StringBuilder sb = new StringBuilder();
            var classes = populatorService.GetAvailableCourses();
            foreach (string s in classes)
            {
                sb.Append($"{s} \n");
            }

            /*
            classes.Select(c => sb.Append($"{c} \n"));*/
            classList = sb.ToString();

            
            return base.Initialize();
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var item = JsonConvert.DeserializeObject<MenuItem>(parameters.Data["MenuItem"]);

            menuItem = new MenuItem(item.Title, null)
            {
                Description = item.Description,
                Title = item.Title            
            };

            title = menuItem.Title;
            description = menuItem.Description;
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
            set { SetProperty(ref _text, value); }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                SetProperty(ref description, value);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                SetProperty(ref title, value);
            }
        }
    }
}