using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe.BL.Model;

namespace Cafe.BL.Controller.Tests
{
    [TestClass()]
    public class OrderControllercsTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName= Guid.NewGuid().ToString();
            var rnd = new Random();
            var user = new UserController(userName);
            var orderController = new Order(user.CurrentUser);
            var food = new Food(foodName,rnd.Next(50,500), rnd.Next(50, 500),rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(5, 20));
            //Act
            orderController.Add(food,5);
            //Assert
            Assert.AreEqual(food.Name,orderController.Foods.FirstOrDefault().Key.Name);

        }
    }
}