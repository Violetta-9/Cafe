using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName,controller.CurrentUser.Name);
        }


        [TestMethod()]
        public void SetNewUserDataTest()
        {   //Arrange
            var userName = Guid.NewGuid().ToString();
            var birtdate = DateTime.Now.AddYears(-18);
            var gender = "man";
            var number = "3456789";
            var addres = "dubrovka23";
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender,birtdate,number,addres);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName,controller2.CurrentUser.Name);
            Assert.AreEqual(birtdate,controller2.CurrentUser.BirdthDate);
            //Assert.AreEqual(gender,controller2.CurrentUser.Gender);
            Assert.AreEqual(number,controller2.CurrentUser.Number);
            Assert.AreEqual(addres,controller2.CurrentUser.Addres);

        }
    }
}