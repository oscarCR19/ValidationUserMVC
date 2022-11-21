using DbExamen2.Database;
using DbExamen2.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DbExamen2.Users
{
    public class Users
    {

        public static User  GetUsers(String email)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                
                new MySqlParameter("pEmail",email),
                

            };
            
            
            DataTable ds = DataBase.ExecuteStoreProcedure("spGetUser", paramList);
            User user = new User();
            foreach (DataRow dr in ds.Rows)
            {


                user.Id = Convert.ToInt32(dr["Id"]);
                user.Name = dr["Name"].ToString();
                user.Email = dr["Email"].ToString();
                user.Datein = Convert.ToDateTime(dr["DateIn"]);
                user.Photo = dr["Photo"].ToString();
                    
                
            }
            
            return user;
        }

        

        public static void InsertUser(User user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                new MySqlParameter("pName", user.Name),
                new MySqlParameter("pEmail",user.Email),
                new MySqlParameter("pPassword",user.Password),
                new MySqlParameter("pPhoto",user.Photo),
                new MySqlParameter("pDatein",user.Datein)
               
            };

            DataBase.ExecStoreProcedure("spInsertUser", paramList);
        }

        public static void UpdatePassword(User user, string password)
        {
            DataBase.ExecStoreProcedure("spUpdatePassword", new List<MySqlParameter>()
            {
                new MySqlParameter("pId", user.Id),
                new MySqlParameter("pPassword", password)
            });
        }

      

        public static int ValidateEmail(User user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                new MySqlParameter("pEmail", user.Email)

            };
            DataTable dt = new DataTable();
            dt= DataBase.ExecuteStoreProcedure("spGetEmail", paramList);

            return dt.Rows.Count;

        }

        public static int ValidateUser(User user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                new MySqlParameter("pEmail", user.Email),
                new MySqlParameter("pPassword", user.Password)

            };
            DataTable dt = new DataTable();
            dt = DataBase.ExecuteStoreProcedure("spValidateUser", paramList);

            return dt.Rows.Count;

        }

        public static int ValidatePasswChang(User user,string password)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {  
                new MySqlParameter("pId", user.Id),
                new MySqlParameter("pPassword", password)
            };
            DataTable dt = new DataTable();
            dt = DataBase.ExecuteStoreProcedure("spValidatePasswChang", paramList);

            return dt.Rows.Count;

        }


    }
}
