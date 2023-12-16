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
    public partial class frmFlights : Form
    {
        public frmFlights()
        {
            InitializeComponent();
        }

        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            new frmViewFlights().Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Fcodetxt.Text == "" || SrcCbx.SelectedItem.ToString() == "" || DestCbx.SelectedItem.ToString() == "" || CapTxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(SrcCbx.SelectedItem.ToString() == DestCbx.SelectedItem.ToString())
            {
                MessageBox.Show("Source and Destination can't be same","Error",MessageBoxButtons.OK);

            }
            
            else
            {
                try
                {

                    con.Open();

                    string qry = @"INSERT INTO tblFlight VALUES ('" + Fcodetxt.Text + "','" + SrcCbx.SelectedItem.ToString() + "','" + DestCbx.SelectedItem.ToString() + "','" + DateTimePicker.Value.ToString() + "','" + CapTxt.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(qry, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Flight Recorded SuccessFully", "Success");
                    Fcodetxt.Text = "";
                    SrcCbx.SelectedItem = null; 
                    DestCbx.SelectedItem = null;
                    CapTxt.Text = "";
                    Fcodetxt.Focus();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fcodetxt.Text = "";
            SrcCbx.SelectedItem = null;
            DestCbx.SelectedItem = null;
            CapTxt.Text = "";
            Fcodetxt.Focus();
        }
    }
}
