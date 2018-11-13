using UWPTodoList.Models;

namespace UWPTodoList.ViewModels
{
    class TodoItemViewModel : BindableBase
    {
        public TodoItemViewModel(TodoItem item = null) => Item = item ?? new TodoItem();

        private TodoItem _item;

        public TodoItem Item
        {
            get => _item;
            set
            {
                if (_item != value)
                {
                    _item = value;

                    OnPropertyChanged();
                }
            }
        }
    }
}
