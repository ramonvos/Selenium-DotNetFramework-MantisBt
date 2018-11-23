
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Utils.DataBaseHelpers
{
    public class DatabaseInteractions
    {
        string connStr = @"Server=192.168.0.187;Port=3306;Database=app_development;Uid=root; Pwd=root; ";
        MySqlConnection conn = null;

        private MySqlConnection GetDBConnection()
        {
            try
            {
                return conn = new MySqlConnection(connStr);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void executaQuery(String query)
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public List<string> retornaDadosQuery(String query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            conn.Open();

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            ds.Tables.Add(table);
            cmd.Connection.Close();

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    lista.Add(ds.Tables[0].Rows[0][i].ToString());
                }
            }
            catch (Exception)
            {

                return null;
            }

            return lista;
        }


        public List<string> retornaListaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);

            MySqlDataReader rdr = cmd.ExecuteReader();

            cmd.Connection.Open();

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            ds.Tables.Add(table);
            cmd.Connection.Close();


            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }

            }
            catch (Exception)
            {

                return null;
            }
            return lista;
        }


    }
}
