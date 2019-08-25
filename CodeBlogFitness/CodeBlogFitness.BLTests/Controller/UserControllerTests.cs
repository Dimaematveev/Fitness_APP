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
            Assert.Fail();
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