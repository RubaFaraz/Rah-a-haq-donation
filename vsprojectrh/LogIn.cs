using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class LogIn : Form
    {
        VSPROJECTSDataContext db;

        public LogIn()
        {
            InitializeComponent();
            label4.Cursor = Cursors.Hand;
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.ShowDialog();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new VSPROJECTSDataContext();
                var user = textBox1.Text;
                var pass = textBox2.Text;

                var check_auto = db.loginns.FirstOrDefault(s => s.Email == user && s.pass == pass);

                if (check_auto != null)
                {
                    var userDetails = db.UserAdds.FirstOrDefault(u => u.Email == user);
                //    var userDetails1 = db.DonateNows.FirstOrDefault(u => u.Email == user);
                    if (userDetails != null)
                    {

                  //      if (userDetails1 != null)
                    //    {
                            User_Screen us = new User_Screen(userDetails.namee,userDetails.Email);

                            us.ShowDialog();
                      //  }
                    }
                    else
                    {
                        MessageBox.Show("User details not found. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
