using AutomacaoMantisBT.Utils.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.TakeScreenshot
{
    public static class TakeScreenShotHelpers
    {
        public static string TakeScreenshot(string path)
        {
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
            string fileName = path + "Screenshot-" + currentDate + ".png";
            
             Screenshot ss = ((ITakesScreenshot)WebdriverHooks.Driver).GetScreenshot();

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
            return fileName;
        }
    }
}
