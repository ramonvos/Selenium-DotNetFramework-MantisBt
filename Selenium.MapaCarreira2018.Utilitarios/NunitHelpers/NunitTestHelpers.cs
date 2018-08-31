﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.MapaCarreira2018.Utilitarios.NunitHelpers
{
    public static class NunitTestHelpers
    {
        public static String GetTestDirectoryName()
        {
            return TestContext.CurrentContext.TestDirectory;
        }


        public static String GetTestCaseName()
        {
            return TestContext.CurrentContext.Test.Name;
        }


        public static String GetTestDescription()
        {
            return TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
        }

        public static String GetTestProperty(string property)
        {
            return TestContext.CurrentContext.Test.Properties.Get(property).ToString();
        }

        public static String GetClassNameTest(int pos)
        {
            String SuiteName = TestContext.CurrentContext.Test.ClassName;

            return SuiteName.Substring(pos);
        }

        public static TestStatus GetTestStatus()
        {
            return TestContext.CurrentContext.Result.Outcome.Status;

        }


    }
}