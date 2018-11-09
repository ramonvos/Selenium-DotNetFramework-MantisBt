using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.ExcelDataDriven
{

    public class ExcelUtil
    {
        
        public DataTable ExcelToDatable(string fileName)
        {
            // open file and returns as stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            // create openXmlReader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //Set the first row as column name
            var result1 = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            // Return as dataset
            DataSet result = excelReader.AsDataSet();
            // Get all tables
            DataTableCollection table = result.Tables;
            // Store in Database
            DataTable resultTable = table["TestData"];
            // return
            return resultTable;

        }

        List<DataCollection> dataCol = new List<DataCollection>();
        public void PopulateInCollection(string fileName)
        {

            DataTable table = ExcelToDatable(fileName);
            for (int row = 1; row <= table.Rows.Count; row++)
            {

                for (int col = 0; col < table.Columns.Count; col++)
                {

                    DataCollection dtTable = new DataCollection()
                    {

                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);

                }
            }
        }

        public string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // Retriving data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal class DataCollection
        {
            public int rowNumber { get; internal set; }
            public string colName { get; internal set; }
            public string colValue { get; internal set; }
        }
    }

}
