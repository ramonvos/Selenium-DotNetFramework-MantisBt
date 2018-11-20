using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace AutomacaoMantisBT.Utils.ProjectUtilities
{
    public class DatabaseConnection
    {
        public void OpenConnection()
        {
            try
            {
                string con = "Server=db;Database=MASSA_TESTES;Uid=root;Pwd=root;";

                string conn = @"Server=192.168.0.187;Port=3306;Database=app_development;Uid=root; Pwd=root; ";

                MySqlConnection objConn = new MySqlConnection(conn);

                //"server=http://192.168.0.187; port=3306; User Id=root; database=MASSA_TESTES; password=root"
                objConn.Open();
                Console.WriteLine("conectado");


                string stm = "SELECT * FROM MASSA_TESTES";
                MySqlCommand cmd = new MySqlCommand(stm, objConn);

                Object dados = cmd.ExecuteNonQuery();

                objConn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
