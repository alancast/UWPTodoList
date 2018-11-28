using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using UWPTodoList.Models;
using Windows.Storage;

namespace UWPTodoList.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
        }

        public async Task Initialize()
        {
            await populateTodoListsCollection();
        }

        private string dbFileName = "lists.json";

        public async void OnItemUpdate()
        {
            await SaveJson();
        }

        private async Task SaveJson()
        {
            var Folder = ApplicationData.Current.LocalFolder;
            var file = await Folder.CreateFileAsync(dbFileName, CreationCollisionOption.ReplaceExisting);
            var data = await file.OpenStreamForWriteAsync();

            using (StreamWriter r = new StreamWriter(data))
            {
                var json = JsonConvert.SerializeObject(Lists);
                r.Write(json);
            }
        }

        private ObservableCollection<TodoList> _lists;
        public ObservableCollection<TodoList> Lists
        {
            get { return _lists; }
            set
            {
                _lists = value;
                OnPropertyChanged("Lists");
            }
        }

        private async Task populateTodoListsCollection()
        {
            await LoadJson(dbFileName);
        }

        private async Task LoadJson(string filename)
        {
            // See if there is already data in local state
            // If there isn't, copy over the data we packaged
            // If there is just read that data
            var localStateFolder = ApplicationData.Current.LocalFolder;
            var localStateFile = await localStateFolder.TryGetItemAsync(dbFileName);

            if (localStateFile == null) // No local state data
            {
                // Copy the file from the install folder to the local folder
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
                var file = await folder.GetFileAsync(dbFileName);
                if (file != null)
                {
                    await file.CopyAsync(localStateFolder, dbFileName, NameCollisionOption.FailIfExists);
                }
            }

            StorageFile listsFile = await localStateFolder.GetFileAsync(filename);
            string json = await FileIO.ReadTextAsync(listsFile);
            Lists = JsonConvert.DeserializeObject<ObservableCollection<TodoList>>(json);
        }
    }
}
