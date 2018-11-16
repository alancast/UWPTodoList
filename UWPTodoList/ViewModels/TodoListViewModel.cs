﻿using System;
using UWPTodoList.Models;

namespace UWPTodoList.ViewModels
{
    public class TodoListViewModel : BindableBase
    {
        public TodoListViewModel(TodoList list, Action onItemUpdate)
        {
            List = list;
            OnItemUpdate = onItemUpdate;
        }

        private TodoList _list;
        private Action OnItemUpdate;

        public TodoList List
        {
            get => _list;
            set
            {
                if (_list != value)
                {
                    _list = value;

                    OnPropertyChanged(string.Empty);
                }
            }
        }


        private TodoItem _selectedItem;
        public TodoItem SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }

        public void AddItem()
        {
            // Create the new Todo Item
            TodoItem item = new TodoItem();
            item.Title = ItemTitle;
            item.Description = ItemDescription;
            item.Visible = true;

            // Add item to the todo list
            _list.Add(item);

            // Reset title and description and notify view of change
            ItemTitle = "";
            ItemDescription = "";
            OnPropertyChanged(string.Empty);
            OnItemUpdate();
        }

        public void RemoveItem()
        {
            _list.Remove(_selectedItem);
            OnPropertyChanged(string.Empty);
            OnItemUpdate();
        }
    }
}
