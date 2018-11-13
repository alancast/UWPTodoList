using UWPTodoList.Models;
using UWPTodoList.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

        public TodoListViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is TodoList && e.Parameter != null)
            {
                ViewModel = new TodoListViewModel((TodoList)e.Parameter);
            }
            base.OnNavigatedTo(e);
        }
    }
}
