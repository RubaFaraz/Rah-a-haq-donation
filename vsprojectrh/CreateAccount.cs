using System;
using System.Linq;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        VSPROJECTSDataContext db;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
        
                db = new VSPROJECTSDataContext();

        
                var name = textBox1.Text.Trim();
                var phoneText = textBox2.Text.Trim();
                var city = textBox4.Text.Trim();
                var address = textBox3.Text.Trim();
                var email = textBox5.Text.Trim();
                var password = textBox6.Text.Trim();
                var confirmPassword = textBox7.Text.Trim();

        
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneText) || string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!long.TryParse(phoneText, out long phone) || phoneText.Length != 10)
                {
                    MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

        
                var existingUser = db.loginns.FirstOrDefault(u => u.Email == email);
                if (existingUser != null)
                {
                    MessageBox.Show("This email is already registered.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

        
                UserAdd newUser = new UserAdd
                {
                    namee = name,
                    phone = phone,
                    city = city,
                    addresss = address,
                    Email = email,
                    pass = password
                };

                loginn newLogin = new loginn
                {
                    Email = email,
                    pass = password
                };

                db.UserAdds.InsertOnSubmit(newUser);
                db.loginns.InsertOnSubmit(newLogin);
                db.SubmitChanges();

        
                MessageBox.Show("User account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
