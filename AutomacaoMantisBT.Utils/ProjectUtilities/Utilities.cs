using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutomacaoMantisBT.Utils.ProjectUtilities
{
    public static class Utilities
    {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static void CreateFolder(string folderName)
        {

            // Specify the directory you want to manipulate.
            //string folderName = NunitHelpers.NunitTestHelpers.GetTestDirectoryName() + ConfigurationManager.AppSettings["LOG_FOLDER_NAME"];
            //string subFolderName = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(folderName))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(folderName);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(folderName));

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        
    }
    
}
