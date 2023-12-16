using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystem
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter dataAdapter = new SqlDataAdapter();


        private void signUp_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void chkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Please enter username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string login = "SELECT * FROM Users WHERE u_username = '" + txtusername.Text + "' and u_password = '" + txtpassword.Text + "'";
                cmd = new SqlCommand(login, con);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    new home().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtusername.Focus();
                }
                con.Close();
            }
        }
    }
}
