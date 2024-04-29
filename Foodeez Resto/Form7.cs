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
    public partial class Form7 : Form
    {
        private string customerID = "";

        public Form7(string user)
        {
            InitializeComponent();
            customerID = user;
            DisplayCustomersData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateValue();

            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }


        private void UpdateValue()
        {
            // Get the input values from textboxes
            string CustomerID = textBox2.Text;
            string Name = textBox1.Text;
            string Contact = textBox3.Text;
            string age = textBox4.Text;
            string gender = textBox5.Text;
            string status = textBox6.Text;

            // Check if CustomerID is provided
            if (string.IsNullOrEmpty(CustomerID))
            {
                MessageBox.Show("Please enter CustomerID.");
                return;
            }

            try
            {
                // Establish connection to MySQL database
                using (MySqlConnection conn = Connect.GetConnection())
                {
                    // Open the connection
                    conn.Open();
                    string updateQuery = "UPDATE customers SET Name = @name, Contact = @contact, age = @age, status = @status, gender = @gender WHERE CustomerID = @customerId";


                    // Create MySqlCommand object and pass SQL query and connection object
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        // Add parameters to SQL command to prevent SQL injection
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@contact", Contact);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@customerId", CustomerID);

                        // Execute command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer information updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No records updated. Customer not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer information: " + ex.Message);
            }
        }

        private void DisplayCustomersData()
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT CustomerID, Name, Contact, age, status, gender FROM customers WHERE  CustomerID =  @customerID";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Assuming ID is a private string field in your class
                        cmd.Parameters.AddWithValue("@customerID", customerID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assign values to textboxes
                                textBox2.Text = reader["CustomerID"].ToString();
                                textBox1.Text = reader["Name"].ToString();
                                textBox3.Text = reader["Contact"].ToString();
                                textBox4.Text = reader["age"].ToString();
                                textBox6.Text = reader["status"].ToString();
                                textBox5.Text = reader["gender"].ToString();
                                // Repeat for other columns as needed
                            }
                            else
                            {
                                // Handle case when no records are found
                                MessageBox.Show("Customer not found");
                            }
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
            this.Hide();
        }
    }
}
