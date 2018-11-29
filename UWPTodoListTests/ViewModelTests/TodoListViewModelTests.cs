using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPTodoList.Models;

namespace ViewModelTests
{
    [TestClass]
    public class TodoListViewModelTests
    {
        [TestMethod]
        public void TestChangeTitle()
        {
            TodoItem item1 = new TodoItem()
            {
                Title = "item 1",
                Description = "item 1 desc",
                Visible = true
            };
            Assert.AreEqual(item1.Title, "item 1");
        }
    }
}
