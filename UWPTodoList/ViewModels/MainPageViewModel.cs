using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
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
            LoadJson("Data/lists.json");
        }

        private void LoadJson(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                var testing = JsonConvert.DeserializeObject<ObservableCollection<TodoList>>(json);
                lists = JsonConvert.DeserializeObject<ObservableCollection<TodoList>>(json);
            }
        }
    }
}
