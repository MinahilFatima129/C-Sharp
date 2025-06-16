using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//.NET libraries to create connection with MySQL database

namespace Employee_Management_System
{
    class DatabaseConnection//Class
    {
        private MySqlConnection connection;//declare declare type MySqlConnection

        public DatabaseConnection()//Constructor 
        {
            string connectionString = "Server=127.0.0.1;Database=EmployeeDB;Uid=root;pwd=Minahil@123";//define connection string
            connection = new MySqlConnection(connectionString);//create database connection
        }
        public MySqlConnection GetConnection()//public method which return MySqlConnection object 
        {
            return connection;
        }
    }
}
