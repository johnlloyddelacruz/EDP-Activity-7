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

    public partial class Form6 : Form
    {

        /*        // MySQL database connection string
                string connectionString = "server=localhost; uid=root; pwd=; database=restaurantdb;";

                // SQL query to select all records from the table
                string selectQuery = "SELECT * FROM Users";

        */
        public Form6()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // MySQL database connection string
            string connectionString = "server=localhost; uid=root; pwd=; database=restaurantdb;";

            // SQL query to insert values into the table
            string insertQuery = "INSERT INTO customers (Name, CustomerID, Contact, age, status, gender) VALUES (@name, @customerID, @contact, @age, 'Active', @gender)";


            try
            {
                // Establish connection to MySQL database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Get user input from textboxes (assuming you have textboxes named txtPassword and txtEmail)
                    string Name = textBox1.Text;
                    string CustomerID = textBox2.Text;
                    string age = textBox4.Text;
                    string Contact = textBox3.Text;
                    string gender = textBox5.Text;

                    // Create MySqlCommand object and pass SQL query and connection object
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        // Add parameters to SQL command to prevent SQL injection
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@customerID", CustomerID);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@contact", Contact);
                        cmd.Parameters.AddWithValue("@gender", gender);


                        // Execute command
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Values inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();

            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();

          

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
            this.Hide();
        }
    }
}





