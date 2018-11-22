
using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.AssertsHelpers;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using AutomacaoMantisBT.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(3)]
    public class ListBugsTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] ListBugPage objList;

        [Test, Description("")]
        public void TEST_ListAllBugs()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objList.ClickIssueDetails();

            ValidationResult.AssertTextInElement(objList.bugId, ListBugPage.selectBug);
        }

        [Test, Description("")]
        public void TEST_ListBugsForPriority()
        {


        }

        [Test, Description("")]
        public void TEST_ListBugsForCriticality()
        {


        }


        [Test, Description("")]
        public void TEST_ListBugsForDateCreateDesc()
        {


        }

        [Test, Description("")]
        public void TEST_ListBugsForDateCreateAsc()
        {


        }

        [Test, Description("")]
        public void TEST_ListBugsForReporter()
        {


        }

        [Test, Description("")]
        public void TEST_ListBugsForStatus()
        {


        }
    }
}
