using System.Collections.ObjectModel;
using UWPTodoList.Models;

namespace UWPTodoList.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
            populateTodoListsCollection();
        }

        public ObservableCollection<TodoList> lists { get; set; }

        private void populateTodoListsCollection()
        {
            // TODO: in the future actually read this list in from a file or something, not just hardcoded

            // Create initial starter items 
            TodoItem item1 = new TodoItem();
            TodoItem item2 = new TodoItem();
            item1.Title = "Item 1";
            item2.Title = "Item 2";
            item1.Description = "Description 1";
            item2.Description = "Description 2";
            item1.Visibile = item2.Visibile = true;

            // Create initial starter lists
            TodoList firstList = new TodoList();
            firstList.ListName = "First List";
            TodoList secondList = new TodoList();
            secondList.ListName = "Second List";
            secondList.Icon = "Shop";

            // Add starter items to list
            firstList.Add(item1);
            firstList.Add(item2);
            secondList.Add(item1);
            secondList.Add(item2);

            // Add list to lists
            lists = new ObservableCollection<TodoList>();
            lists.Add(firstList);
            lists.Add(secondList);
        }
    }
}
