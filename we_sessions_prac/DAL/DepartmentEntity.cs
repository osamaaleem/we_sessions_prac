using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using we_sessions_prac.Models;
using System.Configuration;

namespace we_sessions_prac.DAL
{
    public class DepartmentEntity
    {
        private string connection = ConfigurationManager.ConnectionStrings["dataDb"].ToString();
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        public List<Department> GetList()
        {
        
                List<Department> list = new List<Department>();
                string query = "SELECT * FROM Department";
                sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(new Department() { DempartmentID = Convert.ToInt32(sqlDataReader["depID"].ToString()), Name = sqlDataReader["depName"].ToString()});
                }
                sqlConnection.Close();
            return list;
        }
    }
}