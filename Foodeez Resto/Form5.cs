using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodeez_Resto
{
    public partial class Form5 : Form
    {
        private string userID = "";
        public Form5()
        {
            InitializeComponent();
            DisplayUsersData();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(userID);
            this.Hide();
            form7.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dataGridView1.Rows[e.RowIndex];
                userID = selectedRow.Cells["CustomerID"].Value?.ToString();
            }

        }

        private void DisplayUsersData()
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Select all columns from the Users table
                    string query = "SELECT CustomerID, Name, Contact, age, status, gender FROM customers ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.Columns.Clear();

                        dataGridView1.AutoGenerateColumns = false;

                        dataGridView1.Columns.Add("CustomerID", "CustomerID");
                        dataGridView1.Columns["CustomerID"].DataPropertyName = "CustomerID";
                        dataGridView1.Columns["CustomerID"].Width = 162;

                        dataGridView1.Columns.Add("Name", "Name");
                        dataGridView1.Columns["Name"].DataPropertyName = "Name";
                        dataGridView1.Columns["Name"].Width = 162;

                        dataGridView1.Columns.Add("Contact", "Contact");
                        dataGridView1.Columns["Contact"].DataPropertyName = "Contact";
                        dataGridView1.Columns["Contact"].Width = 162;

                        dataGridView1.Columns.Add("age", "Age");
                        dataGridView1.Columns["age"].DataPropertyName = "age";
                        dataGridView1.Columns["age"].Width = 162;

                        dataGridView1.Columns.Add("status", "Status");
                        dataGridView1.Columns["status"].DataPropertyName = "status";
                        dataGridView1.Columns["status"].Width = 162;

                        dataGridView1.Columns.Add("gender", "Gender");
                        dataGridView1.Columns["gender"].DataPropertyName = "gender";
                        dataGridView1.Columns["gender"].Width = 162;

                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

       /* private void button4_Click(object sender, EventArgs e)
        {
            DisplayUsersData();
        }*/


        private void button3_Click(object sender, EventArgs e)
        {
            // Get the gender or Name from the TextBox
            string searchText = textBox1.Text.Trim();

            // Check if the searchText is a number (assumed to be CustomerID)
            if (int.TryParse(searchText, out int id))
            {
                // Delete based on CustomerID
                /*DeleteCustomerByID(id);*/
            }
            else
            {
                // Delete based on TrainerName
                /*DeleteCustomerByID(searchText);*/
            }

            // Refresh the data in the DataGridView
            DisplayUsersData();
        }

       /* private void DeleteCustomerBygender(int id)
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Prepare the SQL query to delete a customer by gender
                    string query = "DELETE FROM customers WHERE gender = @gender";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Set the parameter value for gender
                        cmd.Parameters.AddWithValue("@gender", id);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Display a success message or perform any additional actions
                        MessageBox.Show("Trainer deleted successfully!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message);
                }
            }
        }


        private void DeleteCustomerByID(int CustomerID)
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Prepare the SQL query to update the status of a customer by CustomerName
                    string query = "UPDATE customers SET status = 'Inactive' WHERE CustomerID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Set the parameter value for Name
                        cmd.Parameters.AddWithValue("@id", CustomerID);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Display a success message or perform any additional actions
                            MessageBox.Show("Customer status Deleted successfully!");
                            textBox1.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Customer not found or status already set to 'Inactive'.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error updating customer status: " + ex.Message);
                }
            }
        }*/



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            // Get the search text from the TextBox
            string searchText = textBox1.Text.Trim();

            // Execute the query with the filter condition
            string query = $"SELECT CustomerID, Name, Contact, age, status, gender FROM customers WHERE Name LIKE '%{searchText}%' OR CustomerID = '{searchText}' ";

            using (MySqlConnection conn = Connect.GetConnection())
            {
                
                        try
                        {
                            conn.Open();

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // Bind the DataTable to the DataGridView
                                dataGridView1.Columns.Clear();

                                dataGridView1.AutoGenerateColumns = false;

                                dataGridView1.Columns.Add("CustomerID", "CustomerID");
                                dataGridView1.Columns["CustomerID"].DataPropertyName = "CustomerID";
                                dataGridView1.Columns["CustomerID"].Width = 162;

                                dataGridView1.Columns.Add("Name", "Name");
                                dataGridView1.Columns["Name"].DataPropertyName = "Name";
                                dataGridView1.Columns["Name"].Width = 162;

                                dataGridView1.Columns.Add("Contact", "Contact");
                                dataGridView1.Columns["Contact"].DataPropertyName = "Contact";
                                dataGridView1.Columns["Contact"].Width = 162;

                                dataGridView1.Columns.Add("age", "Age");
                                dataGridView1.Columns["age"].DataPropertyName = "age";
                                dataGridView1.Columns["age"].Width = 162;

                                dataGridView1.Columns.Add("status", "Status");
                                dataGridView1.Columns["status"].DataPropertyName = "status";
                                dataGridView1.Columns["status"].Width = 162;

                                dataGridView1.Columns.Add("gender", "Gender");
                                dataGridView1.Columns["gender"].DataPropertyName = "gender";
                                dataGridView1.Columns["gender"].Width = 162;

                                dataGridView1.DataSource = dataTable;
                            }
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show("Error connecting to the database: " + ex.Message);
                        }
                    }
                
            }
        }

    }



  


