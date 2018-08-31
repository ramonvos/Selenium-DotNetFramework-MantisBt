using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AutomacaoMantisBT.Utilitarios.NunitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.ExtentReport
{
    public static class Reporter
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;


        static string path = @"C:\Selenium\";
        static string fileName = "ReportTest - " + DateTime.Now.ToLongDateString() + ".html";
        public static void CreateReport()
        {
            var htmlReporter = new ExtentHtmlReporter(path + fileName);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            htmlReporter.Configuration().ChartVisibilityOnOpen = false;

        }

        public static void AddTest()
        {
            _test = _extent.CreateTest("NOme do testes", "Descricao do teste").AssignCategory("Categoria do testes");
        }

        public static void AddTestInfo(string text)
        {
            _test.Log(Status.Info, text);
        }
        public static void FailTest(string text, Exception e)
        {
            _test.Log(Status.Fail, text + e.Message);
        }
        public static void AddStepStatus(string text)
        {
            var StepType = NunitTestHelpers.GetClassNameTest(0);
            string description = NunitTestHelpers.GetTestDescription();
            string nase = NunitTestHelpers.GetTestCaseName();

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

            _test.Log(logstatus, "<pre> Valor informado: [" + text + "]</pre>");

        }

        public static void GenerateReport()
        {
            _extent.Flush();
        }
    }
}
