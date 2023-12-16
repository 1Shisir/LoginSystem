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
    public partial class frmRegister : Form
    {

       


        public frmRegister()
        {
            InitializeComponent();
            
        }
        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");
        static  SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter dataAdapter = new SqlDataAdapter();


        private void BtnRegister_Click_1(object sender, EventArgs e)
        {

            if (txtusername.Text == "" || txtpassword.Text == "" || txtConPassword.Text == "")
            {
                MessageBox.Show("Fill up all the fields properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpassword.Text != txtConPassword.Text)
            {
                MessageBox.Show("Please enter the same password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtConPassword.Text = "";
                txtpassword.Focus();
            }
            else
            {
                con.Open();
                string registereQuery = @"INSERT INTO Users VALUES ('" + txtusername.Text + "', '" + txtpassword.Text + "')";
                cmd = new SqlCommand(registereQuery,con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration Successful","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtusername.Text = "";
                txtpassword.Text = "";
                txtConPassword.Text = "";


            }
        }

        private void chkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxShowPass.Checked)
            {
                txtpassword.PasswordChar =  '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                txtConPassword.PasswordChar = '•';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtConPassword.Text = "";
            txtusername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmlogin().Show();
            this.Hide();
        }
    }
}
