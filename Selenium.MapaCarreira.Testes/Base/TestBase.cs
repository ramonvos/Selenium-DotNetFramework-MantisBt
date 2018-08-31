using Castle.DynamicProxy;
using NUnit.Framework;
using Selenium.MapaCarreira2018.Selenium.PageObjectFactory;
using Selenium.MapaCarreira2018.Selenium.Pages;
using Selenium.MapaCarreira2018.Utilitarios.ExtentReport;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace Selenium.MapaCarreira.Testes.Base
{
    
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


        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Reporter.GenerateReport();
            WebdriverHooks.Driver.Quit();
        }

      
    }
}
