using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using UWPTodoList.Models;

namespace ModelTests.IDataStorage
{
    [TestClass]
    public class JsonDataStorageTests
    {
        [TestMethod]
        public async Task WriteThenReadTodoList()
        {
            JsonDataStorage<TodoList> dataStore = new JsonDataStorage<TodoList>("TodoListTest.json");

            TodoList todoList1 = new TodoList()
            {
                Icon = "Home",
                ListName = "List 1"
            };
            TodoList todoList2 = new TodoList()
            {
                Icon = "Home",
                ListName = "List 2"
            };
            List<TodoList> list = new List<TodoList>();

            list.Add(todoList1);
            list.Add(todoList2);

            await dataStore.SaveData(list);

            List<TodoList> readData = await dataStore.ReadData();

            Assert.AreEqual(readData.Count, 2);
            Assert.AreEqual(readData.Count, list.Count);
            Assert.AreEqual(list[0].ListName, "List 1");
            Assert.AreEqual(list[1].ListName, "List 2");
        }

        [TestMethod]
        public async Task WriteThenReadTodoItems()
        {
            JsonDataStorage<TodoItem> dataStore = new JsonDataStorage<TodoItem>("TodoItemTest.json");

            TodoItem item1 = new TodoItem()
            {
                Title = "Title Item 1",
                Description = "Description Item 1",
                Visible = true
            };
            TodoItem item2 = new TodoItem()
            {
                Title = "Title Item 2",
                Description = "Description Item 2",
                Visible = true
            };
            List<TodoItem> list = new List<TodoItem>();

            list.Add(item1);
            list.Add(item2);

            await dataStore.SaveData(list);

            List<TodoItem> readData = await dataStore.ReadData();

            Assert.AreEqual(readData.Count, 2);
            Assert.AreEqual(readData.Count, list.Count);
            Assert.AreEqual(list[0].Title, "Title Item 1");
            Assert.AreEqual(list[1].Title, "Title Item 2");
        }

        [TestMethod]
        public async Task NonExistentFile()
        {
            JsonDataStorage<TodoList> dataStore = new JsonDataStorage<TodoList>("NonExistentFile");
            List<TodoList> readData = await dataStore.ReadData();
            Assert.IsNotNull(readData);
            Assert.AreEqual(readData.Count, 0);
        }
    }
}
