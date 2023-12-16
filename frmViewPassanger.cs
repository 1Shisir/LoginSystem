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
    public partial class frmViewPassanger : Form
    {
        public frmViewPassanger()
        {
            InitializeComponent();
        }
        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");
        private void Populate()
        {
            con.Open();

            string qry = @"SELECT  * FROM tblPassenger";
            SqlDataAdapter adapter = new SqlDataAdapter(qry,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            PassengerDGV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void frmViewPassanger_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtPiD.Text == "")
            {
                MessageBox.Show("Enter the Passenger to delete","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string sql = @"DELETE FROM tblPassenger where PassId = '" + txtPiD.Text+ "'";
                    SqlCommand sqlCommand = new SqlCommand(sql,con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    Populate();

                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PassengerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPiD.Text = PassengerDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtPname.Text = PassengerDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtPpass.Text = PassengerDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtPadd.Text = PassengerDGV.SelectedRows[0].Cells[3].Value.ToString();
            cbxNation.SelectedItem = PassengerDGV.SelectedRows[0].Cells[4].Value.ToString();
            cbxGender.SelectedItem = PassengerDGV.SelectedRows[0].Cells[5].Value.ToString();
            txtPcontact.Text = PassengerDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPiD.Text = "";
            txtPname.Text = "";
            txtPpass.Text = "";
            txtPadd.Text = "";
            txtPcontact.Text = "";
            cbxNation.SelectedItem = null;
            cbxGender.SelectedItem = null;
            txtPiD.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPiD.Text == "" || txtPadd.Text == "" || txtPcontact.Text == "" || txtPname.Text == "" || txtPpass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();

                    string qwery = @"UPDATE tblPassenger SET PassName = '" + txtPname.Text + "',Passport = '" + txtPpass.Text + "',PassAddress = '" + txtPadd.Text
                        + "',PassNationality = '" + cbxNation.SelectedItem.ToString() + "',PassGender = '" + cbxGender.SelectedItem.ToString() + "',PassPhone = '" + txtPcontact.Text +"' WHERE PassId = '" + txtPiD.Text + "'";
                    SqlCommand cmd = new SqlCommand(qwery,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger updated successfully","Success",MessageBoxButtons.OK);
                    
                    con.Close();
                    Populate();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
