using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vsprojectrh
{
    public partial class Donate : Form
    {
        string email;
        VSPROJECTSDataContext db;

        public Donate(string email)
        {
            InitializeComponent();
            this.email = email;

            comboBox1.Items.Add("- Select -");
            comboBox1.Items.Add("Ramzan Donation");
            comboBox1.Items.Add("Monthly Donation");
            comboBox1.Items.Add("Winter Donation");
            comboBox1.Items.Add("Orphan Donation");

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a donation type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db = new VSPROJECTSDataContext();
                var Rs = Convert.ToInt32(textBox1.Text);
                var phone = Convert.ToInt64(textBox2.Text);

                
                var existingDonation = db.DonateNows.FirstOrDefault(d => d.Email == email);

                if (existingDonation != null)
                {
                    existingDonation.RS += Rs;
                    existingDonation.total_donate += 1;
                    existingDonation.crt = comboBox1.Text;
                  //  existingDonation.DonationDate = date;
                }
                else
                {
                    DonateNow dn = new DonateNow
                    {
                        RS = Rs,
                        total_donate = 1,
                        Email = email,
                        crt = comboBox1.Text,
                        Phone= phone
                    };
                    db.DonateNows.InsertOnSubmit(dn);
                }


                DonationNowShow dns = new DonationNowShow
                {
                    Email = email,
                    RS = Rs,
                    Total_Donate = 1,
                    crt = comboBox1.Text,
                    Phone = phone
                };
                db.DonationNowShows.InsertOnSubmit(dns);

                db.SubmitChanges();

                MessageBox.Show("Donation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update//
            try
            {
                var id = textBox3.Text;

                var donation = db.DonateNows.FirstOrDefault(d => d.Email == id);
                if (donation != null)
                {
                    donation.RS = int.Parse(textBox1.Text);
                    donation.Phone = long.Parse(textBox2.Text);
                    donation.crt = comboBox1.SelectedItem.ToString();

                    db.SubmitChanges();

                    MessageBox.Show("Donation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //buttonSearch.PerformClick();
                    ClearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

    }

        private void button3_Click(object sender, EventArgs e)
        {

                try
                {
                    var id = textBox3.Text;

                    
                    var donation = db.DonateNows.FirstOrDefault(d => d.Email == id);
                
                    if (donation != null)
                    {
                        
                        var confirmResult = MessageBox.Show("Are you sure you want to delete this donation?",
                                                            "Confirm Delete",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                        if (confirmResult == DialogResult.Yes)
                        {
                            
                            db.DonateNows.DeleteOnSubmit(donation);
                            db.SubmitChanges();

                            MessageBox.Show("Donation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                      // buttonSearch.PerformClick();

                           
                            ClearTextBoxes();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void ClearTextBoxes()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            dataGridView1.DataSource = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear
            ClearTextBoxes();

        }

        private void Donate_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            db = new VSPROJECTSDataContext();
            try
            {
                var search = textBox3.Text;
                var check = db.DonateNows.Where(s => s.Email.Contains(search)).ToList();

                if (check.Any())
                {
                    dataGridView1.DataSource = check;
                }
                else
                {
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
