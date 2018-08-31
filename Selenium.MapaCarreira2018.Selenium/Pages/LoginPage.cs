using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira2018.Selenium.Pages
{
    public class LoginPage
    {
       

        public IWebElement txtLogin => WebdriverHooks.Driver.FindElement(By.Id("user_email"));

        public IWebElement txtPass => WebdriverHooks.Driver.FindElement(By.Id("user_password"));

        public IWebElement btnLogin => WebdriverHooks.Driver.FindElement(By.Id("btn-login"));

        public LoginPage NavegarPaginaInicial()
        {

            NavigationHelper.NavigateToPage(ConfigurationManager.AppSettings["URL_BASE"]);

            return new LoginPage();
        }

        public LoginPage LogIn()
        {
            string user = ConfigurationManager.AppSettings["USERNAME"];
            string pass = ConfigurationManager.AppSettings["PASSWORD"];
            txtLogin.TypeInTextBox(user);
            txtPass.TypeInTextBox(pass);
            btnLogin.ClickButton();

            return new LoginPage();


        }

        public LoginPage LogIn(string user, string pass )
        {
            txtLogin.TypeInTextBox(user);
            txtPass.TypeInTextBox(pass);
            btnLogin.ClickButton();

            return new LoginPage();


        }

      
    }
}
