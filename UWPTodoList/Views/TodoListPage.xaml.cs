using UWPTodoList.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPTodoList.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodoListPage : Page
    {
        public TodoListPage()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
        }

        // Uncomment line below and section in TodoListViewModel.cs to use singelton TodoListViewModel
        //public TodoListViewModel ViewModel { get; set; } = TodoListViewModel.Instance;
        public TodoListViewModel ViewModel { get; set; } = new TodoListViewModel();
    }
}
