using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AutomacaoMantisBT.Utils.NunitHelpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace AutomacaoMantisBT.Utils.SeleniumBase
{
    public class WebdriverHooks
    {
        public static IWebDriver Driver { get; set; }

        public static string UrlBase { get; set; }

        public static bool RemoteDriver = false;

        static WebdriverHooks()
        {
            Driver = null;
        }



        public static void Initialize(String browser)
        {
            if (ConfigurationManager.AppSettings["REMOTE_DRIVER"].Equals("true"))
            {
                if (ConfigurationManager.AppSettings["BROWSER"].Equals("chrome"))
                {


                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");
                    options.AddArguments("lang=en-US");
                    
                    Driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["URL_REMOTE"]), options.ToCapabilities(), TimeSpan.FromSeconds(300));


                }



            }
            else 
            {

                if (browser.Equals("firefox"))
                {
                    Driver = GetFirefoxDriver();

                }
                else if (browser.Equals("chrome"))
                {
                    Driver = GetChromeDriver();

                }
                else if (browser.Equals("ie"))
                {
                    Driver = GetIEDriver();

                }
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
            
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }


        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("lang=en-US");
            if (ConfigurationManager.AppSettings["CHROME_HEADLESS"].Equals("true"))
            {
                options.AddArguments("--headless");
            }

            return options;
        }



        
        public static void Quit()
        {
            Driver.Quit();
        }

     

    }
}
