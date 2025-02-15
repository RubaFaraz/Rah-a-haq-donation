using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class User_Screen : Form
    {
        VSPROJECTSDataContext db;

        public long rs;
        private string namee;
        private string email;

        public User_Screen(string namee, string email)
        {
            this.email = email;
            this.namee = namee;
            InitializeComponent();
        }

        private int GetTotalDonation()
        {
            db = new VSPROJECTSDataContext();
            return db.DonationNowShows.Sum(d => d.Total_Donate);
            
        }
        private int GetDS()
        {
            db = new VSPROJECTSDataContext();
            return db.DonationNowShows.Sum(d1 => d1.RS);
        }

        private void User_Screen_Load(object sender, EventArgs e)
        {
            int totalDonation = GetTotalDonation();
            int rss=GetDS();
            label4.Text = "Welcome! " + namee;
            button6.Text = "Total Donations: " + totalDonation.ToString("C");
            button7.Text += rss.ToString("C");  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Donate donate = new Donate(email);
            donate.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            My_Donation md = new My_Donation(email);
            md.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Campaigns campaigns = new Campaigns();
            campaigns.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contect_Us cu = new Contect_Us();
            cu.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://rahehaq.pk/");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
