using System.Collections.Generic;
using System.Threading.Tasks;
using UWPTodoList.Models;

namespace UWPTodoListTests.Fakes
{
    public class FakeIDataStorage<T> : IDataStorage<T>
    {
        public bool _readDataCalled = false;
        public bool _saveDataCalled = false;

        public Task<List<T>> ReadData()
        {
            _readDataCalled = true;

            return Task.Run(() => new List<T>());
        }

        public Task SaveData(List<T> data)
        {
            _saveDataCalled = true;
            return Task.CompletedTask;
        }
    }
}
