﻿using System.Collections.ObjectModel;

namespace UWPTodoList.Models
{
    public class TodoList
    {
        public string ListName { get; set; } = "My Todo List";
        public string Icon { get; set; } = "Home";

        public ObservableCollection<TodoItem> Items { get; } = new ObservableCollection<TodoItem>();

        public void Add(TodoItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void Remove(TodoItem item)
        {
            Items.Remove(item);
        }
    }
}
