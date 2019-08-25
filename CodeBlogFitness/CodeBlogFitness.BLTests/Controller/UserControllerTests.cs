using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange Объявление
            string userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var userController = new UserController(userName);

            //Act действие
            userController.SetNewUserData(gender, birthDate, weight, height);
            var userController2 = new UserController(userName);
            //Assert Проверка
            Assert.AreEqual(userName, userController2.CurrentUser.Name);
            Assert.AreEqual(gender, userController2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, userController2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, userController2.CurrentUser.Weight);
            Assert.AreEqual(height, userController2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange Объявление
            string userName = Guid.NewGuid().ToString();


            //Act действие
            var userController = new UserController(userName);

            //Assert Проверка
            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}