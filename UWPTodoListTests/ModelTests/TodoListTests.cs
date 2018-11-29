using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPTodoList.Models;

namespace ModelTests
{
    [TestClass]
    public class TodoListTests
    {
        [TestMethod]
        public void Defaults()
        {
            TodoList defaultList = new TodoList();
            Assert.AreEqual(defaultList.Icon, "Home");
            Assert.AreEqual(defaultList.ListName, "My Todo List");
            Assert.IsNotNull(defaultList.Items);
            Assert.AreEqual(defaultList.Items.Count, 0);
        }

        [TestMethod]
        public void AddAndRemoveItem()
        {
            TodoList list = new TodoList();
            TodoItem item = new TodoItem();
            Assert.AreEqual(list.Items.Count, 0);
            list.Add(item);
            Assert.AreEqual(list.Items.Count, 1);
            list.Remove(item);
            Assert.AreEqual(list.Items.Count, 0);
        }

        [TestMethod]
        public void DoubleRemove()
        {
            TodoList list = new TodoList();
            TodoItem item = new TodoItem();
            Assert.AreEqual(list.Items.Count, 0);
            list.Add(item);
            Assert.AreEqual(list.Items.Count, 1);
            list.Remove(item);
            Assert.AreEqual(list.Items.Count, 0);
            list.Remove(item);
            Assert.AreEqual(list.Items.Count, 0);
        }

        [TestMethod]
        public void RemoveFromEmptyList()
        {
            TodoList list = new TodoList();
            TodoItem item = new TodoItem();
            Assert.AreEqual(list.Items.Count, 0);
            list.Remove(item);
            Assert.AreEqual(list.Items.Count, 0);
        }

        [TestMethod]
        public void AddDuplicateItem()
        {
            TodoList list = new TodoList();
            TodoItem item = new TodoItem();
            Assert.AreEqual(list.Items.Count, 0);
            list.Add(item);
            Assert.AreEqual(list.Items.Count, 1);
            // Item shouldn't be added because it is a duplicate
            list.Add(item);
            Assert.AreEqual(list.Items.Count, 1);
        }
    }
}
