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
    public partial class frmMyTickets : Form
    {
        public frmMyTickets()
        {
            InitializeComponent();
        }

        static SqlConnection con = new SqlConnection("Data Source=LAPTOP-B3927JIV\\SQLEXPRESS;Initial Catalog=project4thsem;Integrated Security=True");

        private void Populate()
        {
            con.Open();

            string qry = @"SELECT  * FROM tblTickets";
            SqlDataAdapter adapter = new SqlDataAdapter(qry, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            TicketsDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void fillPassenger()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT PassId FROM tblPassenger",con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PassId",typeof(int));
            dt.Load(dr);
            cbxPid.ValueMember = "PassId";
            cbxPid.DataSource = dt;

            con.Close();
        }

        private void fillFlight()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Fcode FROM tblFlight", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Fcode", typeof(int));
            dt.Load(dr);
            cbxFcode.ValueMember = "Fcode";
            cbxFcode.DataSource = dt;

            con.Close();
        }

        string pname, pass, pnat;

        private void fetchPassenger()
        {
            con.Open();

            String sql = @"SELECT * FROM tblPassenger where PassId = '"  + cbxPid.SelectedValue.ToString()+ "'";
            SqlCommand cmd = new SqlCommand(sql,con);
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows) {
                pname = dr["PassName"].ToString();
                pass = dr["Passport"].ToString();
                pnat = dr["PassNationality"].ToString();
                txtPname.Text = pname;
                txtPpass.Text = pass;
                txtPnat.Text = pnat;

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTid.Text == " " ||txtPname.Text == "" || cbxFcode.SelectedItem.ToString() == "" || cbxPid.SelectedItem.ToString() == "" || txtPnat.Text == "" || txtPpass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(txtTamt.Text == " ")
            {
                MessageBox.Show("Amount must be entered");
            }

            else
            {
                try
                {

                    con.Open();

                    string qry = @"INSERT INTO tblTickets VALUES ('" +txtTid.Text + "','" + cbxFcode.SelectedItem.ToString() + "','" + cbxPid.SelectedItem.ToString() + "','" + txtPname.Text + "','"  + txtPpass.Text + "','"  + txtPnat.Text + "','"  +  txtTamt.Text+ "')";
                    SqlCommand sqlCommand = new SqlCommand(qry, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Ticket booked SuccessFully", "Success");

                    con.Close();

                    txtTid.Text = "";
                    cbxFcode.SelectedItem = null;
                    cbxPid.SelectedItem = null;
                    txtPname.Text = "";
                    txtPpass.Text = "";
                    txtTamt.Text = "";
                    txtPnat.Text = "";
                    txtTid.Focus();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTid.Text = "";
            cbxFcode.SelectedItem = null;
            cbxPid.SelectedItem = null;
            txtPname.Text = "";
            txtPpass.Text = "";
            txtTamt.Text = "";
            txtPnat.Text = "";
            txtTid.Focus();
        }

        private void frmMyTickets_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is under Maintainance.","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            fillPassenger();
            fillFlight();
            Populate();
            
        }

        private void cbxPid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchPassenger();
        }
    }
}
