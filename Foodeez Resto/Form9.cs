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
    public partial class Form9 : Form
    {

        private string email; // to store the email received from Form4
        public Form9()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the new password and confirmation password from the TextBoxes
            string newPassword = textBox1.Text;
            string confirmPassword = textBox2.Text;

            // Check if the passwords match
            if (newPassword == confirmPassword)
            {
                // Perform the password change logic here using email
                UpdatePassword(email, newPassword);

                MessageBox.Show("Password changed successfully!");
                this.Hide();
                Form2 form1 = new Form2();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please re-enter the passwords.");
            }
        }

        // Method to update the password in the database
        private void UpdatePassword(string email, string newPassword)
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Prepare the SQL query to update the password
                    string query = "UPDATE users SET password = @Password WHERE email = @Email";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Set the parameter values
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", newPassword);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            this.Hide();
        }
    }
    }

