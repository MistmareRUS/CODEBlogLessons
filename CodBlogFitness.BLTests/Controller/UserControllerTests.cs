using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {   
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";

            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller.CurrentUser.Weight);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();
            //act
            var controller = new UserController(userName);
            //assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}