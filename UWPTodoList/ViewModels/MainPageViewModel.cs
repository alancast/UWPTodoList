using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UWPTodoList.Models;

namespace UWPTodoList.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IDataStorage<TodoList> _datastore;

        public MainPageViewModel(IDataStorage<TodoList> datastore)
        {
            _datastore = datastore;
        }

        public async Task Initialize()
        {
            Lists = new ObservableCollection<TodoList>(await _datastore.ReadData());
        }

        public async Task OnItemUpdate()
        {
            if (Lists != null)
            {
                await _datastore.SaveData(Lists.ToList());
            }
        }

        private ObservableCollection<TodoList> _lists;
        public ObservableCollection<TodoList> Lists
        {
            get { return _lists; }
            set
            {
                if (_lists != value)
                {
                    _lists = value;
                    OnPropertyChanged(nameof(Lists));
                }
            }
        }
    }
}
