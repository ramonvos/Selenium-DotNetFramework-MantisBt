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

            switch (browser)
            {
                case "chrome":
                    Driver = GetChromeDriver();
                    break;
                case "firefox":
                    Driver = GetFirefoxDriver();
                    break;
                case "internetexplorer":
                    Driver = GetIEDriver();
                    break;
            }


            //if (ConfigurationManager.AppSettings["REMOTE_DRIVER"].Equals("true"))
            //{

            //    switch (browser)
            //    {
            //        case "chrome":


            //            break;
            //        case "firefox":
            //            FirefoxOptions firefoxOptions = new FirefoxOptions();
            //            Driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["URL_REMOTE"]), firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(300));
            //            break;
            //        case "internetexplorer":

            //            break;
            //    }

            //}
            //else
            //{

            //    switch (browser)
            //    {
            //        case "chrome":
            //            Driver = GetChromeDriver();
            //            break;
            //        case "firefox":
            //            Driver = GetFirefoxDriver();
            //            break;
            //        case "internetexplorer":
            //            Driver = GetIEDriver();
            //            break;
            //    }


            //}

            // Initialize base URL and maximize browser
            UrlBase = ConfigurationManager.AppSettings["URL_BASE"];

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();

        }

        public static string pathFirefoxDriver = NunitTestHelpers.GetTestDirectoryName();


        private static IWebDriver GetFirefoxDriver()
        {

            if (ConfigurationManager.AppSettings["REMOTE_DRIVER"].Equals("true"))
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                return Driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["URL_REMOTE"]), firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(300));
            }

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(pathFirefoxDriver);
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.SetPreference("intl.accept_languages", "en-us");

            return Driver = new FirefoxDriver(service, options, TimeSpan.FromMinutes(1));

        }

        private static IWebDriver GetChromeDriver()
        {
            if (ConfigurationManager.AppSettings["REMOTE_DRIVER"].Equals("true"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized");
                options.AddArguments("lang=en-US");
                return Driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["URL_REMOTE"]), options.ToCapabilities(), TimeSpan.FromSeconds(300));
            }
            return Driver = new ChromeDriver(GetChromeOptions());

        }

        private static IWebDriver GetIEDriver()
        {
            if (ConfigurationManager.AppSettings["REMOTE_DRIVER"].Equals("true"))
            {
                InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                return Driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["URL_REMOTE"]), ieOptions.ToCapabilities(), TimeSpan.FromSeconds(300));
            }
            
            
            return Driver = new InternetExplorerDriver(pathFirefoxDriver);

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
