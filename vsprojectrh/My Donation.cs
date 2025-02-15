using System;
using System.Linq;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class My_Donation : Form
    {
        string email;
        VSPROJECTSDataContext db;

        public My_Donation(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void My_Donation_Load(object sender, EventArgs e)
        {
            try
            {
                db = new VSPROJECTSDataContext();

                
                var donations = db.DonationNowShows
                                  .Where(d => d.Email == email)
                                  .Select(d => new
                                  {
                                      d.ID,
                                      d.RS,
                                      d.Total_Donate,
                                      d.crt,
                                      d.Phone
                                  })
                                  .ToList();

                
                dataGridView1.DataSource = donations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
