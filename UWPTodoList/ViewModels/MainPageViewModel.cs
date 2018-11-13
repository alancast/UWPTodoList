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

            // Create initial starter list
            TodoList starterList = new TodoList();
            starterList.ListName = "Starter List";

            // Create initial starter items 
            TodoItem item1 = new TodoItem();
            TodoItem item2 = new TodoItem();
            item1.Title = "Item 1";
            item2.Title = "Item 2";
            item1.Description = "Description 1";
            item2.Description = "Description 2";
            item1.Visibile = item2.Visibile = true;

            // Add starter items to list
            starterList.Add(item1);
            starterList.Add(item2);

            // Add list to lists
            lists = new ObservableCollection<TodoList>();
            lists.Add(starterList);
        }
    }
}
