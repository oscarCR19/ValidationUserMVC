using System.Data;
using MySql.Data.MySqlClient;


namespace DbExamen2.Database
{
    public class DataBase
    {
        //Conexion string
        const string user = "root";
        const string password = "root1234";
        const string servidor = @"localhost";
        const string port = "3306";
        const string baseDatos = "ExamenDB2";
        const string strConexion = $"server={servidor};Port={port};uid={user};pwd={password};database={baseDatos}";



        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //insert
        public static void ExecStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
