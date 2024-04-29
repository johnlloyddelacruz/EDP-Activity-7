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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Assuming you have usernameTextBox and passwordTextBox for user input
            string email = textBox1.Text.Trim(); // Assuming email is used as the username
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password");
                return; // Stop further execution
            }

            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();


                    // Check if the provided email and password exist in the database
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @email AND Password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Continue with any additional code related to the successful login
                            this.Hide();
                            Form3 form3 = new Form3();
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password");
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);

                }
            }

            /*Form3 form3 = new Form3();
            this.Hide();
            form3.Show();*/
        }
            
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PasswordReco().ShowDialog();
            this.Hide();
        }
    }
}
