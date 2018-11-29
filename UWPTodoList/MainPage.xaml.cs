using Microsoft.Extensions.DependencyInjection;
using System;
using UWPTodoList.Models;
using UWPTodoList.ViewModels;
using UWPTodoList.Views;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPTodoList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection()
                .AddSingleton<IDataStorage<TodoList>, JsonDataStorage<TodoList>>()
                .BuildServiceProvider();

            ViewModel = new MainPageViewModel(serviceCollection.GetService<IDataStorage<TodoList>>());
            Loading += initializeViewModel;
        }

        private async void initializeViewModel(Windows.UI.Xaml.FrameworkElement sender, object args)
        {
            await ViewModel.Initialize();
        }

        public MainPageViewModel ViewModel { get; set; }

        #region NavigationView event handlers
        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                TodoList ItemContent = args.SelectedItem as TodoList;
                if (ItemContent != null)
                {
                    int index = -1;
                    string selectedListName = ItemContent.ListName;
                    for (int i = 0; i < ViewModel.Lists.Count; i++)
                    {
                        //case insensitive search
                        if (String.Equals(ViewModel.Lists[i].ListName, selectedListName, StringComparison.OrdinalIgnoreCase))
                        {
                            index = i;
                            break;
                        }
                    }
                    contentFrame.Navigate(typeof(TodoListPage), new { list = ViewModel.Lists[index], onItemUpdate = new Action(() => { ViewModel.OnItemUpdate(); } )});
                }
            }
        }
        #endregion
    }
}
