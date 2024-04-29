using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodeez_Resto
{
    public partial class PasswordReco : Form
    {

        private string email; // to store the verified ema
        public PasswordReco()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailToVerify = textBox1.Text;

            if (VerifyEmailExists(emailToVerify))
            {
                email = emailToVerify; // Remember the verified email
               
                new Form9().ShowDialog(this);
                this.Hide();

               /* this.Hide();
                Form9 form9 = new Form9(email);
                form9.Show()*/;
            }
            else
            {
                MessageBox.Show("Email does not exist. Please enter a valid email.");
            }
        }

        private bool VerifyEmailExists(string email)
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error verifying email: " + ex.Message);
                    return false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            this.Hide();
        }
    }
    }

