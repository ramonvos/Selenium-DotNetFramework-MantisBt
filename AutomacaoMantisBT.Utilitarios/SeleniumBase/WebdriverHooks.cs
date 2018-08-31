using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AutomacaoMantisBT.Utilitarios.NunitHelpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace AutomacaoMantisBT.Utilitarios.SeleniumBase
{
    public class WebdriverHooks
    {
        public static IWebDriver Driver { get; set; }

        public static string UrlBase { get; set; }

        static WebdriverHooks()
        {
            Driver = null;
        }

        public static void Initialize(String browser)
        {

            if (browser.Equals("Firefox"))
            {
                Driver = GetFirefoxDriver();

            }
            else if (browser.Equals("Chrome"))
            {
                Driver = GetChromeDriver();

            }
            else if (browser.Equals("InternetExplorer"))
            {
                Driver = GetIEDriver();

            }
        

            // Initialize base URL and maximize browser
            UrlBase = ConfigurationManager.AppSettings["URL_BASE"];

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();

        }

        public static string pathFirefoxDriver = NunitTestHelpers.GetTestDirectoryName();


        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(pathFirefoxDriver);
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        
        public static void Quit()
        {
            Driver.Quit();
        }

     

    }
}
