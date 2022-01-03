using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MoverTestApp.Interface;
using MoverTestApp.Model;
using MoverTestProject1.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestMoverProject
{
    public class InventoryControllerTest    
    {
        [Fact]
        public async Task Get_Return_All_Inventories()
        {
            // I I use the 3A Pattern ( Arrange-Act-Assert) 
            // Arrange 

            // I add FakeitEasy DLL for adding fake Inventory repository 
            // as our InventorysController accept as a IInventory interface object "datasource"
            int count = 5;
            var dataStore = A.Fake<IInventoryRepository>();
            var fakeInventories = A.CollectionOfDummy<Inventory>(count).AsEnumerable();
            A.CallTo(() => dataStore.Get()).Returns(Task.FromResult(fakeInventories));
            var controller = new InventorysController(dataStore);

            //Act
            var actionResult = await controller.GetInventorys();

            //Assert
            var result = actionResult as List<Inventory>;
            Assert.Equal(count, result.Count());
        }
       
    }
}
