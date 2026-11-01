using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace insertData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
private void button3_Click(object sender, EventArgs e)
{

            string email = textBox2.Text;
            string password = textBox3.Text;

            if (!email.Contains('@'))
            {
                MessageBox.Show("Email is not Valid");
            }
            else if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters!");
            }
            else
            {
                MessageBox.Show("Validation Successfully");


            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

    SqlConnection con = new SqlConnection(cs);

    string query = "INSERT INTO students VALUES(@username, @email, @password)";

    SqlCommand cmd = new SqlCommand(query, con);

    cmd.Parameters.AddWithValue("@username", textBox1.Text);
    cmd.Parameters.AddWithValue("@email", textBox2.Text);
    cmd.Parameters.AddWithValue("@password", textBox3.Text);

    con.Open();

    int a = cmd.ExecuteNonQuery();

    if (a > 0)
    {
        MessageBox.Show("Data inserted Successfully");
    }
    else
    {
        MessageBox.Show("Customer insertion failed");
    }

    con.Close();
            }
}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = textBox3.UseSystemPasswordChar;

            if (check)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
