using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using AutomacaoMantisBT.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utils.AssertsHelpers;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(8)]
    public class ManageUsersTests : TestBase
    {
        [PageObject]
        LoginPage objLogin;
        [PageObject]
        HomePage objHome;
        [PageObject]
        ManageUsersPage objUsers;
        string menuManage = "menuManage";

        [Test]
        public void TEST_ManageUsersCreateNewAccount()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.CreateNewUser("Name test " + Guid.NewGuid().ToString(), "real name test", "teste." + Guid.NewGuid() + "@teste", "reporter").SaveNewUser();

            ValidationResult.AssertElementContainsText(objUsers.msgSucesso, "Created user");

        }

        [Test]
        public void TEST_ManageUsersCreateNewAccountUserRequired()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.CreateNewUser(string.Empty, "real name test", "teste." + Guid.NewGuid() + "@teste", "reporter").SaveNewUser();


            ValidationResult.AssertElementContainsText(objUsers.msgErro, "The username is invalid. Usernames may only contain Latin letters, numbers, spaces, hyphens, dots, plus signs and underscores");

        }

        [Test]
        public void TEST_ManageUsersCreateNewAccountUserAlreadyExists()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.CreateNewUser("teste", "real name test", "teste@teste", "reporter").SaveNewUser();

            ValidationResult.AssertElementContainsText(objUsers.msgErro, "That username is already being used. Please go back and select another one.");

        }


        [Test]
        public void TEST_ManageUsersCreateNewAccountUserEmailAlreadyExists()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.CreateNewUser("teste " + Guid.NewGuid(), "real name test", "teste@teste", "reporter").SaveNewUser();

            ValidationResult.AssertElementContainsText(objUsers.msgErro, "That email is already being used. Please go back and select another one.");

        }


        [Test]
        public void TEST_ManageUsersUpdateUser()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.CreateNewUser("Name test " + Guid.NewGuid().ToString(), "real name test", "teste." + Guid.NewGuid() + "@teste", "reporter").SaveNewUser();

            objUsers.UpdateUser("Name test updated " + Guid.NewGuid().ToString(), "real name test", "teste." + Guid.NewGuid() + "@teste", "reporter").SaveUpdateUser();


            ValidationResult.AssertElementContainsText(objUsers.msgSucesso, "Operation successful.");


        }

        [Test]
        public void TEST_ManageUsersResetPassword()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.ResetPassword();

            ValidationResult.AssertElementContainsText(objUsers.msgSucesso, "A confirmation request has been sent to the selected user's e-mail address. Using this, the user will be able to change their password.");


        }

        [Test]
        public void TEST_ManageUsersDeleteUser()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objUsers.DeleteUser();

            ValidationResult.AssertElementContainsText(objUsers.msgSucesso, "Operation successful.");
        }
    }
}
