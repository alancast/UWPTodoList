using System;
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
            dynamic args = e.Parameter;
            if (args != null && args.list is TodoList && args.onItemUpdate is Action)
            {
                ViewModel = new TodoListViewModel((TodoList)args.list, (Action)args.onItemUpdate);
            }
            base.OnNavigatedTo(e);
        }
    }
}
