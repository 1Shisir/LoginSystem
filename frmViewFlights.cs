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
    public partial class frmViewFlights : Form
    {
        public frmViewFlights()
        {
            InitializeComponent();
        }
        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");

        private void Populate()
        {
            con.Open();

            string qry = @"SELECT  * FROM tblFlight";
            SqlDataAdapter adapter = new SqlDataAdapter(qry, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            FlightsDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void frmViewFlights_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtFcode.Text == "")
            {
                MessageBox.Show("Enter the flight id to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string sql = @"DELETE FROM tblFlight where Fcode = '" + txtFcode.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(sql, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Flight Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    Populate();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtFcode.Text = "";
            txtCap.Text = "";
            cbxSrc.SelectedItem = null;
            cbxDest.SelectedItem = null;

        }

        private void FlightsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFcode.Text = FlightsDGV.SelectedRows[0].Cells[0].Value.ToString();
            cbxSrc.SelectedItem = FlightsDGV.SelectedRows[0].Cells[1].Value.ToString();
            cbxDest.SelectedItem = FlightsDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtCap.Text = FlightsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFcode.Text == "" || txtCap.Text == "" || cbxSrc.SelectedItem.ToString() == "" || cbxDest.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();

                    string qwery = @"UPDATE tblFlight SET Fcap = '" + txtCap.Text + "',Fsrc = '" + cbxSrc.SelectedItem.ToString() + "',Fdest = '" + cbxDest.SelectedItem.ToString() + "',Fdate = '" + dateTime.Value.Date.ToString() + "' WHERE Fcode = '" + txtFcode.Text + "'";
                    SqlCommand cmd = new SqlCommand(qwery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight updated successfully", "Success", MessageBoxButtons.OK);

                    con.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
