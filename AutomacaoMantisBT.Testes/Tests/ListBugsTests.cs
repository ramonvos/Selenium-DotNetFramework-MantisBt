
using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira.Testes.Tests
{
    [TestFixture, Order(3)]
    public class ListBugsTests : TestBase
    {
        [PageObject] LoginPage objLogin;

        [Test, Description("")]
        public void TEST_ListAllBugs()
        {

            
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
