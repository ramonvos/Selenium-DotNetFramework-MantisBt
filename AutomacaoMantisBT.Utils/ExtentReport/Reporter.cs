using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AutomacaoMantisBT.Utils.NunitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using AutomacaoMantisBT.Utils.ProjectUtilities;

namespace AutomacaoMantisBT.Utils.ExtentReport
{
    public static class Reporter
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;
        public static string reportFolderName;
        public static string currentDate;
        public static string screenshotsFolder;

        static string fileName = "ReportTest - " + DateTime.Now.ToLongDateString() + ".html";
        public static void CreateReport()
        {
            if (_extent == null)
            {

                reportFolderName = ConfigurationManager.AppSettings["LOG_FOLDER_NAME"];
                currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                screenshotsFolder = "Screenshots";

                Utilities.CreateFolder(NunitTestHelpers.GetTestDirectoryName() + "\\" + reportFolderName);
                Utilities.CreateFolder(NunitTestHelpers.GetTestDirectoryName() + "\\" + reportFolderName + "\\" + currentDate);
                Utilities.CreateFolder(NunitTestHelpers.GetTestDirectoryName() + "\\" + reportFolderName + "\\" + currentDate + "\\"+ screenshotsFolder);

                var htmlReporter = new ExtentHtmlReporter(NunitTestHelpers.GetTestDirectoryName() + "\\" + reportFolderName + "\\" + currentDate + "\\" + fileName);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                htmlReporter.Configuration().ChartVisibilityOnOpen = false;
            }

        }

        public static void AddTest()
        {
            string testName = NunitTestHelpers.GetTestCaseName(); // Get Test Name
            string testDescription = NunitTestHelpers.GetTestDescription(); // Get  Test Description
            string testCategory = NunitTestHelpers.GetClassNameTest(35); //Get Class name - Subtring para ignorar o nome da solution

            _test = _extent.CreateTest(testName, testDescription).AssignCategory(testCategory);
        }

        public static void AddTestInfo(string text)
        {
            _test.Log(Status.Info, text);
           


        }

        public static void TestException(Exception e)
        {
            _test.Fail(e);
        }

        public static void WriteTestStatus()
        {
            var status = NunitTestHelpers.GetTestStatus();
            var stacktrace = string.IsNullOrEmpty(NunitTestHelpers.GetStackTraceResultTest())
                    ? ""
                    : string.Format("{0}", NunitTestHelpers.GetStackTraceResultTest());
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Status do Teste: " + logstatus + "<pre>"+stacktrace+"</pre>");

        }
        public static void AddStepStatus(string text)
        {
            var StepType = NunitTestHelpers.GetClassNameTest(0);
            string description = NunitTestHelpers.GetTestDescription();
            string nase = NunitTestHelpers.GetTestCaseName();

            _test.Log(GetTestStatus(), "<pre> Valor informado: [" + text + "]</pre>");

        }

        public static void AddScreenShot()
        {
            
            string screenshotPath = TakeScreenshot.TakeScreenShotHelpers.TakeScreenshot(NunitTestHelpers.GetTestDirectoryName() + "\\" + reportFolderName + "\\" + currentDate + "\\" + screenshotsFolder + "\\");

            var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();

            _test.Log(GetTestStatus(), SeleniumBase.WebdriverHooks.Driver.Url, mediaModel);
        }

        public static Status GetTestStatus()
        {
            TestStatus status = NunitTestHelpers.GetTestStatus();
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            return logstatus;
        }

        public static void GenerateReport()
        {
            _extent.Flush();
        }
    }
}
