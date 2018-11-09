using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.AssertsHelpers;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(7)]
    public class ViewBugDetailsTest : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] ListBugPage objList;

        [Test, Description("")]
        public void TEST_ViewBugDetailsFirstFromList()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ViewBugDetailsRandom()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ViewBugDetailsSendAReminder()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ViewBugDetailsJumpToNotes()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ViewBugDetailsAddNote()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ViewBugDetailsJumpToHistory()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

    }
}
