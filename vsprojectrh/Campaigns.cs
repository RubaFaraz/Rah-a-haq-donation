using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class Campaigns : Form
    {
        VSPROJECTSDataContext db;
        private int currentIndex = 0;
        private List<CampaignsTable> campaignsList;

        public Campaigns()
        {
            InitializeComponent();
            comboBox1.Items.Add("Old age home");
            comboBox1.Items.Add("Orphanage");
            comboBox1.Items.Add("Ramzan drive");
            comboBox1.Items.Add("Winter drive");
        }

        private void Campaigns_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new VSPROJECTSDataContext();
               var des = textBox1.Text;
                var tag = textBox2.Text;
                var selectedCampaign = comboBox1.SelectedItem.ToString();

                camp newCamp = new camp
                {
                    details = des,
                   targets = tag,
                    campaign_type = selectedCampaign
                };

                db.camps.InsertOnSubmit(newCamp);
                db.SubmitChanges();

                MessageBox.Show("Campaign added successfully!");
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (db == null)
                {
                    db = new VSPROJECTSDataContext();
                }

                var campaigns = from ct in db.camps
                                select new
                                {
                                    ct.id,
                                    ct.details,
                                    ct.targets,
                                    ct.campaign_type
                                };

                if (campaigns.Any())
                {
                    dataGridView1.DataSource = campaigns.ToList();
                }
                else
                {
                    MessageBox.Show("No campaigns found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\UNEEB\\Desktop\\c1.jpg";
            FramePic framePic = new FramePic(imagePath);
            framePic.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\UNEEB\\Desktop\\c.jpg";
            FramePic framePic = new FramePic(imagePath);
            framePic.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\UNEEB\\Desktop\\c.jpg";
            FramePic framePic = new FramePic(imagePath);
            framePic.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\UNEEB\\Desktop\\c2m.jpg";
            FramePic framePic = new FramePic(imagePath);
            framePic.ShowDialog();
        }
    }
}
