using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using UWPTodoList.Models;
using UWPTodoList.ViewModels;
using UWPTodoListTests.Fakes;

namespace ViewModelTests
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private List<string> propertiesChanged = new List<string>();

        MainPageViewModel Setup(IDataStorage<TodoList> dataStorage = null)
        {
            if (dataStorage == null)
            {
                dataStorage = new FakeIDataStorage<TodoList>();
            }
            
            MainPageViewModel mpvm = new MainPageViewModel(dataStorage);
            mpvm.PropertyChanged += (sender, e) =>
            {
                propertiesChanged.Add(e.PropertyName);
            };

            return mpvm;
        }

        void TearDown()
        {
            propertiesChanged.Clear();
        }

        [TestMethod]
        public void DoNothing()
        {
            MainPageViewModel mpvm = Setup();
            Assert.AreEqual(0, 0);
            TearDown();
        }

        [TestMethod]
        public async Task ReadDataOnInitialize()
        {
            FakeIDataStorage<TodoList> fids = new FakeIDataStorage<TodoList>();
            MainPageViewModel mpvm = Setup(fids);


            Assert.IsFalse(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            await mpvm.Initialize();

            Assert.IsTrue(propertiesChanged.Contains(nameof(mpvm.Lists)));
            Assert.IsTrue(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            TearDown();
        }

        [TestMethod]
        public async Task SaveWithoutInitializeCall()
        {
            FakeIDataStorage<TodoList> fids = new FakeIDataStorage<TodoList>();
            MainPageViewModel mpvm = Setup(fids);


            Assert.IsFalse(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            await mpvm.OnItemUpdate();
            Assert.AreEqual(propertiesChanged.Count, 0);
            Assert.IsFalse(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            TearDown();
        }

        [TestMethod]
        public async Task SaveOnItemUpdate()
        {
            FakeIDataStorage<TodoList> fids = new FakeIDataStorage<TodoList>();
            MainPageViewModel mpvm = Setup(fids);


            Assert.IsFalse(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            await mpvm.Initialize();
            Assert.AreEqual(propertiesChanged.Count, 1);
            Assert.IsTrue(propertiesChanged.Contains(nameof(mpvm.Lists)));
            Assert.IsTrue(fids._readDataCalled);
            Assert.IsFalse(fids._saveDataCalled);

            await mpvm.OnItemUpdate();
            Assert.AreEqual(propertiesChanged.Count, 1);
            Assert.IsTrue(fids._readDataCalled);
            Assert.IsTrue(fids._saveDataCalled);

            TearDown();
        }
    }
}
