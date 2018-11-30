using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UWPTodoList.Models;
using UWPTodoList.ViewModels;

namespace ViewModelTests
{
    [TestClass]
    public class TodoListViewModelTests
    {
        private int itemUpdatedCount = 0;
        private List<string> propertiesChanged = new List<string>();

        [TestMethod]
        public void AddEmptyItem()
        {
            TodoListViewModel tlvm = Setup();

            tlvm.AddItem();
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemTitle)));
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemDescription)));
            Assert.AreEqual(itemUpdatedCount, 1);

            TearDown();
        }

        [TestMethod]
        public void AddItemWithTitleNoDescription()
        {
            TodoListViewModel tlvm = Setup();

            tlvm.ItemTitle = "AddItemWithTitle";
            tlvm.AddItem();
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemTitle)));
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemDescription)));
            Assert.AreEqual(itemUpdatedCount, 1);

            // Title should be there and description should not be null
            Assert.AreEqual(tlvm.List.Items[0].Title, "AddItemWithTitle");
            Assert.IsNotNull(tlvm.List.Items[0].Description);
            Assert.AreEqual(tlvm.List.Items[0].Description, "");

            // Title and Description are reset once item is added
            Assert.AreEqual(tlvm.ItemTitle, "");
            Assert.AreEqual(tlvm.ItemDescription, "");

            TearDown();
        }

        [TestMethod]
        public void AddItemWithTitleAndDescription()
        {
            TodoListViewModel tlvm = Setup();

            tlvm.ItemTitle = "AddItemWithTitleAndDescription Title";
            tlvm.ItemDescription = "AddItemWithTitleAndDescription Description";
            tlvm.AddItem();
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemTitle)));
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.ItemDescription)));
            Assert.AreEqual(itemUpdatedCount, 1);

            // Title and description should be there
            Assert.AreEqual(tlvm.List.Items[0].Title, "AddItemWithTitleAndDescription Title");
            Assert.AreEqual(tlvm.List.Items[0].Description, "AddItemWithTitleAndDescription Description");

            // Title and Description are reset once item is added
            Assert.AreEqual(tlvm.ItemTitle, "");
            Assert.AreEqual(tlvm.ItemDescription, "");

            TearDown();
        }

        [TestMethod]
        public void ChangeList()
        {
            TodoListViewModel tlvm = Setup();
            Assert.IsFalse(propertiesChanged.Contains(nameof(tlvm.List)));
            Assert.AreEqual(tlvm.List.Items.Count, 0);

            TodoList newList = new TodoList();
            newList.Add(new TodoItem());
            tlvm.List = newList;
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.List)));
            Assert.AreEqual(tlvm.List.Items.Count, 1);

            TearDown();
        }

        [TestMethod]
        public void SelectedItem()
        {
            TodoListViewModel tlvm = Setup();
            Assert.IsFalse(tlvm.IsItemSelected);
            Assert.IsNull(tlvm.SelectedItem);
            Assert.AreEqual(propertiesChanged.Count, 0);

            TodoItem item = new TodoItem();
            tlvm.SelectedItem = item;

            Assert.IsTrue(tlvm.IsItemSelected);
            Assert.IsNotNull(tlvm.SelectedItem);
            Assert.AreEqual(tlvm.SelectedItem, item);

            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.SelectedItem)));
            Assert.IsTrue(propertiesChanged.Contains(nameof(tlvm.IsItemSelected)));

            TearDown();
        }

        [TestMethod]
        public void RemoveItem()
        {
            TodoListViewModel tlvm = Setup();
            Assert.AreEqual(tlvm.List.Items.Count, 0);

            tlvm.AddItem();
            Assert.AreEqual(tlvm.List.Items.Count, 1);
            Assert.AreEqual(itemUpdatedCount, 1);

            tlvm.SelectedItem = tlvm.List.Items[0];
            Assert.IsNotNull(tlvm.SelectedItem);
            Assert.IsTrue(tlvm.IsItemSelected);

            tlvm.RemoveItem();
            Assert.IsNull(tlvm.SelectedItem);
            Assert.IsFalse(tlvm.IsItemSelected);
            Assert.AreEqual(tlvm.List.Items.Count, 0);
            Assert.AreEqual(itemUpdatedCount, 2);

            TearDown();
        }

        void fakeOnItemUpdate()
        {
            itemUpdatedCount++;
        }

        TodoListViewModel Setup(TodoList list = null, Action itemUpdateAction = null)
        {
            if (list == null)
            {
                list = new TodoList();
            }
            
            if (itemUpdateAction == null)
            {
                itemUpdateAction = fakeOnItemUpdate;
            }

            TodoListViewModel tlvm = new TodoListViewModel(list, itemUpdateAction);
            tlvm.PropertyChanged += (sender, e) =>
            {
                propertiesChanged.Add(e.PropertyName);
            };

            return tlvm;
        }

        void TearDown()
        {
            propertiesChanged.Clear();
            itemUpdatedCount = 0;
        }
    }
}
