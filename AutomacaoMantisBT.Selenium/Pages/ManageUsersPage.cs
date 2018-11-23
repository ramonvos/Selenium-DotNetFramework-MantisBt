using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using AutomacaoMantisBT.Utils.WaitHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class ManageUsersPage
    {
        public IWebElement linkManageUsers => WebdriverHooks.Driver.FindElement(By.LinkText("Manage Users"));
        public IWebElement linkCreateNewAccount => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='manage-user-div']/div/form/fieldset/button"));

        private By txtUsernameLocator => By.Id("user-username");
        public IWebElement txtUsername => WebdriverHooks.Driver.FindElement(By.Id("user-username"));

        public IWebElement txtRealUsername => WebdriverHooks.Driver.FindElement(By.Id("user-realname"));

        public IWebElement txtEmail => WebdriverHooks.Driver.FindElement(By.Id("email-field"));

        public IWebElement ddlAccessLevel => WebdriverHooks.Driver.FindElement(By.Id("user-access-level"));

        public IWebElement btnSaveUser => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Create User']"));

        private By txtUsernameLocatorEdit => By.Id("edit-username");
        public IWebElement txtUsernameEdit => WebdriverHooks.Driver.FindElement(By.Id("edit-username"));

        public IWebElement txtRealUsernameEdit => WebdriverHooks.Driver.FindElement(By.Id("edit-realname"));

        public IWebElement txtEmailEdit => WebdriverHooks.Driver.FindElement(By.Id("email-field"));
        public IWebElement ddlAccessLevelEdit => WebdriverHooks.Driver.FindElement(By.Id("edit-access-level"));

        public IWebElement btnUpdateUser => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Update User']"));

        public IWebElement btnResetPass => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Reset Password']"));
        public IWebElement btnDelete => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Delete User']"));

        public IWebElement btnConfirmDelete => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Delete Account']"));

        public IWebElement msgSucesso => WebdriverHooks.Driver.FindElement(By.CssSelector("div.alert.alert-success.center"));
        public IWebElement msgSucessoLocator => WebdriverHooks.Driver.FindElement(By.CssSelector("div.alert.alert-success.center"));

        public IWebElement msgErro => WebdriverHooks.Driver.FindElement(By.CssSelector("div.alert.alert-danger"));

        public IWebElement linkFirstUserToList => WebdriverHooks.Driver.FindElement(By.XPath("//td/a"));

        public IWebElement linkSecondUserToList => WebdriverHooks.Driver.FindElement(By.XPath("//tr[2]/td/a"));


        public ManageUsersPage CreateNewUser(string name, string realName, string email, string accessLevel)
        {
            linkManageUsers.ClickLink();
            linkCreateNewAccount.ClickButton();

            WaitForElementHelpers.WaitForElementDisplayed(txtUsernameLocator);
            txtUsername.TypeInTextBox(name);
            txtRealUsername.TypeInTextBox(realName);
            txtEmail.TypeInTextBox(email);
            ddlAccessLevel.SelectText(accessLevel);

            return new ManageUsersPage();
        }

        public ManageUsersPage UpdateUser(string name, string realName, string email, string accessLevel)
        {


            WaitForElementHelpers.WaitForElementDisplayed(txtUsernameLocatorEdit);
            txtUsernameEdit.ClearAndTypeInTextBox(name);
            txtRealUsernameEdit.ClearAndTypeInTextBox(realName);
            txtEmailEdit.ClearAndTypeInTextBox(email);
            ddlAccessLevelEdit.SelectText(accessLevel);

            return new ManageUsersPage();
        }


        public ManageUsersPage ResetPassword()
        {

            linkManageUsers.ClickLink();
            linkFirstUserToList.ClickButton();

            btnResetPass.ClickButton();

            return new ManageUsersPage();
        }

        public ManageUsersPage DeleteUser()
        {

            linkManageUsers.ClickLink();
            linkSecondUserToList.ClickButton();

            btnDelete.ClickButton();
            btnConfirmDelete.ClickButton();

            return new ManageUsersPage();
        }

        public ManageUsersPage SaveNewUser()
        {
            btnSaveUser.ClickButton();
            return new ManageUsersPage();
        }


        public ManageUsersPage SaveUpdateUser()
        {
            btnUpdateUser.ClickButton();
            return new ManageUsersPage();
        }
    }
}
