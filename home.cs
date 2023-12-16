using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LoginSystem
{


    public partial class home : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nButtomRect,
            int nWidthEllipse,
            int nHeightEllipse

            );
        public home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel4.Height = Btndashboard.Height;
            panel4.Top = Btndashboard.Top;
            panel4.Left = Btndashboard.Left;
            Btndashboard.BackColor = Color.FromArgb(46, 51, 73);


            lblTitle.Text = "Home";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill,TopLevel = false ,TopMost = true};
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {
            
        }

        private void Btndashboard_Click(object sender, EventArgs e)
        {
            panel4.Height = Btndashboard.Height;
            panel4.Top = Btndashboard.Top;
            panel4.Left = Btndashboard.Left;
            Btndashboard.BackColor = Color.FromArgb(46, 51, 73);


            lblTitle.Text = "Home";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void BtnUserInfo_Click(object sender, EventArgs e)
        {
            panel4.Height = BtnUserInfo.Height;
            panel4.Top = BtnUserInfo.Top;
            //panel3.Left = BtnUserInfo.Left;
            BtnUserInfo.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Flights";
            this.pnlFormLoader.Controls.Clear();
            frmFlights frmFlights_vrb = new frmFlights() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmFlights_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmFlights_vrb);
            frmFlights_vrb.Show();
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            panel4.Height = BtnTickets.Height;
            panel4.Top = BtnTickets.Top;
            //panel3.Left = BtnTickets.Left;
            BtnTickets.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tickets";
            this.pnlFormLoader.Controls.Clear();
            frmMyTickets frmMyTickets_vrb = new frmMyTickets() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmMyTickets_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmMyTickets_vrb);
            frmMyTickets_vrb.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            panel4.Height = BtnSettings.Height;
            panel4.Top = BtnSettings.Top;
            // panel3.Left= BtnSettings.Left;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Passengers";
            this.pnlFormLoader.Controls.Clear();
            frmSettings frmSettings_vrb = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSettings_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmSettings_vrb);
            frmSettings_vrb.Show();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            panel4.Height = BtnAbout.Height;
            panel4.Top = BtnAbout.Top;
            // panel3.Left = BtnAbout.Left;
            BtnAbout.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Cancel Ticket";
            this.pnlFormLoader.Controls.Clear();
            frmAboutUs frmAboutUs_vrb = new frmAboutUs() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAboutUs_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmAboutUs_vrb);
            frmAboutUs_vrb.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            panel4.Height = BtnLogout.Height;
            panel4.Top = BtnLogout.Top;
            //panel3.Left =BtnLogout.Left;
            BtnLogout.BackColor = Color.FromArgb(46, 51, 73);

            if (MessageBox.Show("Want to Log-out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                new frmlogin().Show();
                this.Hide();
            }
            
        }

        private void Btndashboard_Leave(object sender, EventArgs e)
        {
            Btndashboard.BackColor = Color.FromArgb(24,30,54);
        }

        private void BtnUserInfo_Leave(object sender, EventArgs e)
        {
            BtnUserInfo.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnTickets_Leave(object sender, EventArgs e)
        {
            BtnTickets.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnAbout_Leave(object sender, EventArgs e)
        {
            BtnAbout.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnLogout_Leave(object sender, EventArgs e)
        {
            BtnLogout.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Do you really want to close the program", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==  DialogResult.Yes)
            {
                Application.Exit();
            }
          
        }
    }
}
