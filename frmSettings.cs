using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginSystem
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmViewPassanger().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PassId.Text == "" || PassName.Text == "" || txtPassAddress.Text == "" || txtPassPhone.Text == "" || txtPassport.Text == "")
            {
                MessageBox.Show("Please Fill all the details.","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if ( txtPassPhone.Text != "0-9" && txtPassPhone.TextLength != 10)
            {
                MessageBox.Show("Phone Number must be 10 digits number","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(txtPassport.TextLength != 6)
            {
                MessageBox.Show("Passport must be 6 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try 
                { 
                    con.Open();

                    String qry = @"INSERT INTO tblPassenger VALUES ('" +PassId.Text+ "','" + PassName.Text+ "','" + txtPassport.Text+ "','" + txtPassAddress.Text+ "','" + NationalityCbx.SelectedItem.ToString()+ "','" + GenderCbx.SelectedItem.ToString()+ "','" + txtPassPhone.Text+ "')";
                    SqlCommand cmd = new SqlCommand(qry,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details Added SuccessFully","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    PassId.Text = "";
                    PassName.Text = "";
                    txtPassport.Text = "";
                    txtPassAddress.Text = "";
                    txtPassPhone.Text = "";
                    GenderCbx.SelectedItem = null;
                    NationalityCbx.SelectedItem= null;
                    PassId.Focus();

                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PassId.Text = "";
            PassName.Text = "";
            txtPassport.Text = "";
            txtPassAddress.Text = "";
            txtPassPhone.Text = "";
            NationalityCbx.SelectedItem = null;
            GenderCbx.SelectedItem = null;
            PassId.Focus();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            PassId.Focus();
        }
    }
}
