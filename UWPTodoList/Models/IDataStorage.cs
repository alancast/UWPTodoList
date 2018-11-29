using System.Collections.Generic;
using System.Threading.Tasks;

namespace UWPTodoList.Models
{
    public interface IDataStorage<T>
    {
        Task SaveData(List<T> data);
        Task<List<T>> ReadData();
    }
}
