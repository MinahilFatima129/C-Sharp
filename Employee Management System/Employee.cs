using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string position = textBox3.Text;
            string salary = textBox4.Text;

            string query = "INSERT INTO EMPLOYEES(Id,Name,Position,Salary) Values (@Id,@Name,@Position,@Salary)";//@Id placeholder 
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())//Creates a MySQL connection using the DatabaseConnection class.
            {
                conn.Open();//Opens the database connection.
                using (MySqlCommand cmd = new MySqlCommand(query, conn))//Creates a MySqlCommand object with the SQL query and connection.
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@Salary", salary);//These lines pass actual values to the query.
                    cmd.ExecuteNonQuery();//Yeh query database mein ek naya record insert karegi, lekin koi data return nahi karegi.
                }
            }
            MessageBox.Show("Record Inserted Successfully");
            LoadData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string position = textBox3.Text;
            string salary = textBox4.Text;

            string query = "UPDATE employees SET Name=@Name,Position=@Position,Salary=@Salary WHERE Id=@Id";//@Id placeholder & UPDATE Query
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())//Creates a MySQL connection using the DatabaseConnection class.
            {
                conn.Open();//Opens the database connection.
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.ExecuteNonQuery();// Runs the SQL command on the database
                }
            }
            MessageBox.Show("\uD83D\uDCBC Record updated successfully! But changing salary won't make you rich \uD83E\uDD11\"");
            LoadData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            int id = int.Parse(textBox1.Text);


            string query = "DELETE FROM employees WHERE Id=@Id";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))//Creates a MySqlCommand object with the SQL query and connection.
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();//You don’t get a result set — instead, it just makes changes in the database.
                }
            }
            MessageBox.Show("Record Deleted Successfully");
            LoadData();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT * FROM employees";
            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                  using (MySqlDataAdapter adapter=new MySqlDataAdapter(cmd))//MySqlDataAdapter uses the command to fetch data.
                    {
                        DataTable dt = new DataTable();//DataTable is a temporary table in memory.
                        adapter.Fill(dt);//Fill(dt) copies the result into the DataTable.
                        dataGridView1.DataSource = dt;//it sets dataGridView1's data source to this table
                    }
                }
            }
        }
    }
}
