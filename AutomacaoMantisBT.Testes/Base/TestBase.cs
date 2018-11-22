using Castle.DynamicProxy;
using NUnit.Framework;
using AutomacaoMantisBT.Utils.ExtentReport;
using AutomacaoMantisBT.Utils.SeleniumBase;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using AutomacaoMantisBT.Utils.DependencyInjection;

namespace AutomacaoMantisBT.Testes.Base
{
    [SetUpFixture]
    public class TestBase 
    {
        private ProxyGenerator ProxyGenerator;

        
        public TestBase()
        {

            this.ProxyGenerator = new ProxyGenerator();
            if (WebdriverHooks.Driver == null)
            {
                WebdriverHooks.Initialize(ConfigurationManager.AppSettings["Browser"]);
            }
            
            InjectPageObjects(CollectPageObjects(), null);

        }
        


        private void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
        {
            foreach (FieldInfo field in fields)
            {
                field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
            }
        }

        private List<FieldInfo> CollectPageObjects()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (FieldInfo field in this.GetType().GetRuntimeFields())
            {
                if (field.GetCustomAttribute(typeof(PageObject)) != null)
                    fields.Add(field);
            }

            return fields;
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

            Reporter.CreateReport();
        }

        [SetUp]
        public void SetupTest()
        {

            Reporter.AddTest();

        }

        [TearDown]
        public void TearDownTest()
        {

            Reporter.WriteTestStatus();
            Reporter.AddScreenShot();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Reporter.GenerateReport();
            WebdriverHooks.Driver.Quit();
        }

      
    }
}
