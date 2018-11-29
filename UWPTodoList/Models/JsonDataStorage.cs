using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPTodoList.Models
{
    public class JsonDataStorage<T> : IDataStorage<T>
    {
        private string _filename;

        public JsonDataStorage(string filename = "lists.json")
        {
            _filename = filename;
        }

        public async Task<List<T>> ReadData()
        {
            // See if there is already data in local state
            // If there isn't, copy over the data we packaged
            // If there is just read that data
            var localStateFolder = ApplicationData.Current.LocalFolder;
            var localStateFile = await localStateFolder.TryGetItemAsync(_filename);

            if (localStateFile == null) // No local state data
            {
                try
                {
                    // Copy the file from the install folder to the local folder
                    var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
                    var file = await folder.GetFileAsync(_filename);
                    if (file != null)
                    {
                        await file.CopyAsync(localStateFolder, _filename, NameCollisionOption.FailIfExists);
                    }
                }
                catch (Exception)
                {
                    return new List<T>();
                }
                
            }

            StorageFile listsFile = await localStateFolder.GetFileAsync(_filename);
            string json = await FileIO.ReadTextAsync(listsFile);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public async Task SaveData(List<T> data)
        {
            var Folder = ApplicationData.Current.LocalFolder;
            var file = await Folder.CreateFileAsync(_filename, CreationCollisionOption.ReplaceExisting);
            var writeData = await file.OpenStreamForWriteAsync();

            using (StreamWriter r = new StreamWriter(writeData))
            {
                var json = JsonConvert.SerializeObject(data);
                r.Write(json);
            }
        }
    }
}
