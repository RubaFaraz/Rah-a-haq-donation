using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class FramePic : Form
    {
        public string img;
        private Image img1;

        public FramePic(string img)
        {
            this.img = img;
            InitializeComponent();
            if (File.Exists(img))
            {
                img1 = Image.FromFile(img);
            }
            else
            {
                MessageBox.Show("Image file not found.");
            }
        }

        private void FramePic_Load(object sender, EventArgs e)
        {
            if (img != null)
            {
                pictureBox1.Image = img1;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
