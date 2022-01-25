//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UserWS.Controllers;
using UserServiceDataLayer.Objects;
using NUnit.Framework;
using Moq;

namespace UnitTestUserServiceDL
{
    public class ModelsUsersTest
    {
        UserController UserController;
        string ValidToken;
        string InvalidToken;

        [SetUp]
        public void Setup() {
            UserController = new UserController();
            ValidToken = UserController.GetToken("admon", "123");
            InvalidToken = Guid.NewGuid().ToString();
        }

        [Test]
        public void LoginUserTest_Works()
        {
            //Arrange                       
            LoginProbe objLoginProbe = new LoginProbe();
            objLoginProbe.UserName = "admon";
            objLoginProbe.Password = "123";                   
            //Act
            var result = UserController.GetToken(objLoginProbe.UserName, objLoginProbe.Password);
            //Assert
            Assert.IsNotNull(result);            
        }

        [Test]
        public void LoginUserTest_Fails()
        {
            //Arrange                       
            LoginProbe objLoginProbe = new LoginProbe();
            objLoginProbe.UserName = "akjsdjlaksd";
            objLoginProbe.Password = "123";
            //Act
            var result = UserController.GetToken(objLoginProbe.UserName, objLoginProbe.Password);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CreateUserValidToken_Works()
        {
            //Arrange      
            
            BOUser objTest = new BOUser()
            {
                IdUser = long.MinValue,
                UserName = "testUT",
                Password = "testUT",
                Fullname= "Ippo Makanaouchi",
                Address = "lawjdl",
                Phone = "12314123",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = 2,
            };
            //Act
            var result = UserController.CreateUser(objTest, ValidToken);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateUserInvalidToken_Fails()
        {
            //Arrange                  
            BOUser objTest = new BOUser()
            {
                IdUser = long.MinValue,
                UserName = "testUT",
                Password = "testUT",
                Fullname = "Ippo Makanaouchi",
                Address = "lawjdl",
                Phone = "12314123",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = 2,
            };
            //Act
            var result = UserController.CreateUser(objTest, InvalidToken);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CreateUserNoIdRol_Fails()
        {
            //Arrange                  
            BOUser objTest = new BOUser()
            {
                IdUser = long.MinValue,
                UserName = "testUT",
                Password = "testUT",
                Fullname = "Ippo Makanaouchi",
                Address = "lawjdl",
                Phone = "12314123",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = short.MinValue,
            };
            //Act
            var result = UserController.CreateUser(objTest, InvalidToken);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateUserValidToken_Works()
        {
            //Arrange                  
            BOUser objTest = new BOUser()
            {
                IdUser = 3,
                UserName = "visitante",
                Password = "123",
                Fullname = "Tested UT",
                Address = "Calle Falsa 123",
                Phone = "189237891",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = 1,
            };
            //Act
            var result = UserController.UpdateUser(objTest, ValidToken);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateUserInvalidToken_Fails()
        {
            //Arrange                  
            BOUser objTest = new BOUser()
            {
                IdUser = 3,
                UserName = "visitante",
                Password = "123",
                Fullname = "Tested UT",
                Address = "Calle Falsa 123",
                Phone = "189237891",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = 1,
            };
            //Act
            var result = UserController.UpdateUser(objTest, InvalidToken);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReadUserInfo_Works()
        {
            //Arrange
            long idUserToken = 1;
            //Act
            long result = UserController.ReadUserInfo(ValidToken).IdUser;
            //Assert
            Assert.Equals(result, idUserToken);            
        }

        [Test]
        public void ReadUserInfoInvalidToken_Fails()
        {
            //Arrange
            long idUserToken = 1;
            //Act
            long result = UserController.ReadUserInfo(InvalidToken).IdUser;
            //Assert
            Assert.IsNull(result);
            Assert.AreNotEqual(result, idUserToken);
        }

        [Test]
        public void DeleteUserValidToken_Works()
        {
            //Arrange                                   
            BOUser objTest = new BOUser()
            {
                IdUser = long.MinValue,
                UserName = "testUT",
                Password = "testUT",
                Fullname = "Ippo Makanaouchi",
                Address = "lawjdl",
                Phone = "12314123",
                Email = "aaiwoi@lksdf.com",
                Age = 20,
                IdRol = short.MinValue,
            };
            UserController.CreateUser(objTest, InvalidToken);
            string TempToken = UserController.GetToken(objTest.UserName, objTest.Password);
            long idUser = UserController.ReadUserInfo(TempToken).IdUser;            
                
            //Act
            var result = UserController.DeleteUser(idUser, ValidToken);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteUserValidToken_FailsNull()
        {
            //Arrange                                   
            long idUser = 122000;

            //Act
            var result = UserController.DeleteUser(idUser, ValidToken);
            //Assert
            Assert.IsNull(result);            
        }

        [Test]
        public void DeleteUserValidToken_FailsFalse()
        {
            //Arrange                                   
            long idUser = 122000;

            //Act
            var result = UserController.DeleteUser(idUser, ValidToken);
            //Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void GetUsersList_Works()
        {
            //Arrange
            //Act
            var result = UserController.GetUsersList(ValidToken);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUsersListInvalidToken_Fails()
        {
            //Arrange
            //Act
            var result = UserController.GetUsersList(InvalidToken);
            //Assert
            Assert.IsNull(result);            
        }

    }

    public class LoginProbe
    {
        public LoginProbe() { }
        public string UserName { get; set;}
        public string Password { get; set; }
    }
}
