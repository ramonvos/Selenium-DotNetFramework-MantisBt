using AutomacaoMantisBT.Utils.SeleniumBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class MouseOverHelper
    {
        public static void MouseOverClickContext(IWebElement element)
        {
            Actions act = new Actions(WebdriverHooks.Driver);
            //IWebElement ele = ObjectRepository.Driver.FindElement(locator);
            act.ContextClick(element)
                .Build()
                .Perform();

            //Thread.Sleep(5000);


        }

        public static void MouseOverDranNDrop(IWebElement elemSrc, IWebElement elemTar)
        {
            Actions act = new Actions(WebdriverHooks.Driver);
            //IWebElement src = elemSrc;
            //IWebElement tar = elemSrc;
            act.DragAndDrop(elemSrc, elemTar)
                .Build()
                .Perform();

            //Thread.Sleep(5000);


        }

        public static void MouseOverClickNHold(IWebElement elemSrc, IWebElement elemTar)
        {
            Actions act = new Actions(WebdriverHooks.Driver);
            //IWebElement src = ObjectRepository.Driver.FindElement(locatorSrc);
            //IWebElement tar = ObjectRepository.Driver.FindElement(locatorTar);
            act.ClickAndHold(elemSrc)
                .MoveToElement(elemTar, 0, 30)
                .Release()
                .Build()
                .Perform();
        }
    }
}
