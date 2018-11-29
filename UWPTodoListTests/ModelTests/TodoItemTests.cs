using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPTodoList.Models;

namespace ModelTests
{
    [TestClass]
    public class TodoItemTests
    {
        // This class is in large part useless for now. 
        // There isn't much with this model worth testing but the file is still here to help demonstrate the file layout
        [TestMethod]
        public void Defaults()
        {
            TodoItem defaultItem = new TodoItem();
            Assert.AreEqual(defaultItem.Title, "Title Default");
            Assert.AreEqual(defaultItem.Description, "Description Default");
            Assert.IsTrue(defaultItem.Visible);
        }
    }
}
