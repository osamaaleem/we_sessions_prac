using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using we_sessions_prac.Models;

namespace we_sessions_prac.DAL
{
    public class UserEntity
    {
        public UserEntity()
        {
            sqlConn = ConfigurationManager.ConnectionStrings["dataDb"].ToString();
            conn = new SqlConnection(sqlConn);
        }
        private string sqlConn,query;
        private SqlConnection conn;
        private SqlDataReader reader;
        private SqlCommand cmd;
        public bool IsValidUser(Login login)
        {
            query = $"SELECT * FROM Users WHERE username LIKE '{login.Username}' AND password LIKE '{login.Password}'";
            cmd = new SqlCommand(query, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public int SignUp(Register reg)
        {
            int RowsAffected = 0;
            query = $"INSERT INTO Users VALUES('{reg.UserName}','{reg.FirstName}','{reg.LastName}','{reg.Email}','{reg.Password}')";
            cmd = new SqlCommand(query, conn);
            conn.Open();
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
            }
            conn.Close();
            return RowsAffected;
        }
    }
}