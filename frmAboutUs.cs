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
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");

        private void Populate()
        {
            con.Open();

            string qry = @"SELECT  * FROM tblCancel";
            SqlDataAdapter adapter = new SqlDataAdapter(qry, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            CancelDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void fillTicket()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Tid FROM tblTickets", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tid", typeof(int));
            dt.Load(dr);
            cbxTid.ValueMember = "Tid";
            cbxTid.DataSource = dt;

            con.Close();
        }

        private void fetchFlight()
        {
            con.Open();

            String sql = @"SELECT * FROM tblTickets where Tid = '" + cbxTid.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtFcode.Text = dr["Fcode"].ToString();

            }

            con.Close();
        }

        private void delete()
        {
            if (txtCid.Text == "")
            {
                MessageBox.Show("Enter the Cancel id to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string sql = @"DELETE FROM tblFlight where Fcode = '" + txtCid.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(sql, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tickets Cancelled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Populate();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (txtCid.Text == " " || txtFcode.Text == "" || cbxTid.SelectedItem.ToString() == "" )
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {

                    con.Open();

                    string qry = @"INSERT INTO tblCancel VALUES ('" + txtCid.Text + "','" + cbxTid.SelectedItem.ToString() + "','" + txtFcode.Text+ "','" + CDateTimePicker.Value.ToString() + "')";
                    SqlCommand sqlCommand = new SqlCommand(qry, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Ticket Cancelled SuccessFully", "Success");
                    con.Close();
                    txtCid.Text = "";
                    cbxTid.SelectedItem = null;
                    txtFcode.Text = "";
                    txtCid.Focus();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            
        }

        private void frmAboutUs_Load(object sender, EventArgs e)
        {
            fillTicket();
            Populate();
        }

        private void cbxTid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchFlight();
        }
    }
}
