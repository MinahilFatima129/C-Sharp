using System.IO;
using System.Reflection.Metadata.Ecma335;
namespace Employee_Management_System
{
    public partial class Form1 : Form
    {
        private const string UserDataFilePath = "UserData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(AuthenticateUser(username,password))
            {
                Employee em = new Employee();
                em.Show();
            }
            else
            {
                MessageBox.Show("Trying to sneak in without logging in? Nice try!!!");
            }

        }
        private bool AuthenticateUser(string username,string password)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Lenovo\source\repos\Employee Management System\UserData.txt");// Reads all lines from the text file that contains saved user data.
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');//Splits the line by a comma , into an array.
                if (parts.Length==2)//Checks if the line was properly formatted, i.e., contains exactly 2 parts (username and password).
                {
                    string storedUsername = parts[0];//Stores the username and password read from the file into separate variables.
                    string storedPassword = parts[1];

                    if(username== storedUsername && password== storedPassword)//Compares the input username/password with the ones stored in the file.
                    {
                        MessageBox.Show("\uD83D\uDD0D You sneaked in... Welcome Agent 129!", "Top Secret \uD83D\uDD11", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;//Successfuly authentication Done
                    }


                }
            }
            return false;//authentication failed
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("\u2764 Welcome to the Employee Management System \u2764", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
