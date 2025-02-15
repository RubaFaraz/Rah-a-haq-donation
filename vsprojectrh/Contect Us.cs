using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class Contect_Us : Form
    {
        public Contect_Us()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.instagram.com/rahehaq.official\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=61562999011214&mibextid=ZbWKwL");
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
                System.Diagnostics.Process.Start("https://www.tiktok.com/@rahehaq.official?_t=8oCtK2Rcotd&_r=1\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        VSPROJECTSDataContext db;
        private void button4_Click(object sender, EventArgs e)
        {
            db= new VSPROJECTSDataContext(); 
            try
            {
                var msgs=textBox1.Text;
                msg m=new msg();
                m.msg1 = msgs;
                db.msgs.InsertOnSubmit(m);
                db.SubmitChanges();
                MessageBox.Show("Your Msg Send Successfully ");
                textBox1.Text = " ";
                

            }catch(Exception ex)
            {

            }
           
        }

        private void Contect_Us_Load(object sender, EventArgs e)
        {


        }
        private void Contect_Us_Load_1(object sender, EventArgs e)
        {
            foreach (var control in new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 })
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, control.Width, control.Height);
                control.Region = new Region(path);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
