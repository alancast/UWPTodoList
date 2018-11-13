using System.Collections.ObjectModel;

namespace UWPTodoList.Models
{
    public class TodoList
    {
        public string ListName { get; set; } = "My Todo List";

        public ObservableCollection<TodoItem> Items { get; set; } = new ObservableCollection<TodoItem>();

        public void Add(TodoItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }
    }
}
