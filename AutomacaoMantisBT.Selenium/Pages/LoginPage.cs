﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utils.ProjectUtilities;
using AutomacaoMantisBT.Selenium.ExcelDataDriven;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class LoginPage
    {
       

        public IWebElement txtLogin => WebdriverHooks.Driver.FindElement(By.Id("username"));

        public IWebElement txtPass => WebdriverHooks.Driver.FindElement(By.Id("password"));

        public IWebElement btnEntrar => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Login']"));

        //public IWebElement msgErroLogin => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div/div/div/div/div[4]/p"));
        public IWebElement msgErroLogin => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div/div/div/div/div[4]"));


        public LoginPage NavigateToLoginPage()
        {
            WebdriverHooks.Driver.Manage().Cookies.DeleteAllCookies();
            NavigationHelper.NavigateToPage(ConfigurationManager.AppSettings["URL_BASE"]+ "login_page.php");

            return new LoginPage();
        }

        public LoginPage LogIn()
        {
            string user = ConfigurationManager.AppSettings["USERNAME"];
            string pass = ConfigurationManager.AppSettings["PASSWORD"];
            txtLogin.TypeInTextBox(user);
            btnEntrar.ClickButton();

            txtPass.TypeInTextBox(pass);
            btnEntrar.ClickButton();

            return new LoginPage();


        }

        public LoginPage LogIn(string user, string pass )
        {
            
            txtLogin.TypeInTextBox(user);
            btnEntrar.ClickButton();
            if (user.HasValue())
            {
                txtPass.TypeInTextBox(pass);
                btnEntrar.ClickButton();
            }

        


            return new LoginPage();


        }

        public LoginPage LogInDataDriven(string key)
        {
            String fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];

            ExcelUtil util = new ExcelUtil();
        
            util.PopulateInCollection(fileName);

            String userName = util.ReadData(2, "Column0");//Login
            String pass = util.ReadData(2, "Column1");//senha 01

            txtLogin.TypeInTextBox(userName);
            btnEntrar.ClickButton();

            txtPass.TypeInTextBox(pass);
            btnEntrar.ClickButton();

            return new LoginPage();


        }


    }
}
