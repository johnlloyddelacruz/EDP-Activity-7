using MySql.Data.MySqlClient;
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
using OfficeOpenXml;



namespace Foodeez_Resto
{
    public partial class Form10 : Form
    {
        private string userID = "";

        // Array to store the Excel template file paths
        private string[] excelTemplates = {
            @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Menu Report.xlsx",
            @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Orders Report.xlsx",
            @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Reservation Report.xlsx"
        };

        public Form10()
        {
            InitializeComponent();
            DisplayMenuData();
            DisplayOrdersData();
            DisplayReservationsData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dataGridView1.Rows[e.RowIndex];
                userID = selectedRow.Cells["ItemID"].Value?.ToString();
            }
        }

        private void DisplayMenuData()
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Select all columns from the Users table
                    string query = "SELECT ItemID, ItemName, Category, Price, Quantity, NumGuests FROM menu ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.Columns.Clear();

                        dataGridView1.AutoGenerateColumns = false;

                        dataGridView1.Columns.Add("ItemID", "ItemID");
                        dataGridView1.Columns["ItemID"].DataPropertyName = "ItemID";
                        dataGridView1.Columns["ItemID"].Width = 140;

                        dataGridView1.Columns.Add("ItemName", "ItemName");
                        dataGridView1.Columns["ItemName"].DataPropertyName = "ItemName";
                        dataGridView1.Columns["ItemName"].Width = 140;

                        dataGridView1.Columns.Add("Category", "Category");
                        dataGridView1.Columns["Category"].DataPropertyName = "Category";
                        dataGridView1.Columns["Category"].Width = 140;

                        dataGridView1.Columns.Add("Price", "Price");
                        dataGridView1.Columns["Price"].DataPropertyName = "Price";
                        dataGridView1.Columns["Price"].Width = 140;

                        dataGridView1.Columns.Add("Quantity", "Quantity");
                        dataGridView1.Columns["Quantity"].DataPropertyName = "Quantity";
                        dataGridView1.Columns["Quantity"].Width = 140;

                        dataGridView1.Columns.Add("NumGuests", "NumGuests");
                        dataGridView1.Columns["NumGuests"].DataPropertyName = "NumGuests";
                        dataGridView1.Columns["NumGuests"].Width = 140;

                        dataGridView1.DataSource = dataTable;
                    }
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dataGridView2.Rows[e.RowIndex];
                userID = selectedRow.Cells["OrderID"].Value?.ToString();
            }
        }

        private void DisplayOrdersData()
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Select all columns from the Users table
                    string query = "SELECT OrderID, ItemID, Quantity, OrderDate, CustomerID FROM orders ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView2.Columns.Clear();

                        dataGridView2.AutoGenerateColumns = false;

                        dataGridView2.Columns.Add("OrderID", "OrderID");
                        dataGridView2.Columns["OrderID"].DataPropertyName = "OrderID";
                        dataGridView2.Columns["OrderID"].Width = 140;

                        dataGridView2.Columns.Add("ItemID", "ItemID");
                        dataGridView2.Columns["ItemID"].DataPropertyName = "ItemID";
                        dataGridView2.Columns["ItemID"].Width = 140;

                        dataGridView2.Columns.Add("Quantity", "Quantity");
                        dataGridView2.Columns["Quantity"].DataPropertyName = "Quantity";
                        dataGridView2.Columns["Quantity"].Width = 140;

                        dataGridView2.Columns.Add("OrderDate", "OrderDate");
                        dataGridView2.Columns["OrderDate"].DataPropertyName = "OrderDate";
                        dataGridView2.Columns["OrderDate"].Width = 140;

                        dataGridView2.Columns.Add("CustomerID", "CustomerID");
                        dataGridView2.Columns["CustomerID"].DataPropertyName = "CustomerID";
                        dataGridView2.Columns["CustomerID"].Width = 140;

                        dataGridView2.DataSource = dataTable;
                    }
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dataGridView3.Rows[e.RowIndex];
                userID = selectedRow.Cells["ReservationID"].Value?.ToString();
            }
        }

        private void DisplayReservationsData()
        {
            using (MySqlConnection conn = Connect.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Select all columns from the Users table
                    string query = "SELECT ReservationID, CustomerID, ReservationDate, ReservationTime, NumGuests FROM reservations ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView3.Columns.Clear();

                        dataGridView3.AutoGenerateColumns = false;

                        dataGridView3.Columns.Add("ReservationID", "ReservationID");
                        dataGridView3.Columns["ReservationID"].DataPropertyName = "ReservationID";
                        dataGridView3.Columns["ReservationID"].Width = 140;

                        dataGridView3.Columns.Add("CustomerID", "CustomerID");
                        dataGridView3.Columns["CustomerID"].DataPropertyName = "CustomerID";
                        dataGridView3.Columns["CustomerID"].Width = 140;

                        dataGridView3.Columns.Add("ReservationDate", "ReservationDate");
                        dataGridView3.Columns["ReservationDate"].DataPropertyName = "ReservationDate";
                        dataGridView3.Columns["ReservationDate"].Width = 140;

                        dataGridView3.Columns.Add("ReservationTime", "ReservationTime");
                        dataGridView3.Columns["ReservationTime"].DataPropertyName = "ReservationTime";
                        dataGridView3.Columns["ReservationTime"].Width = 140;

                        dataGridView3.Columns.Add("NumGuests", "NumGuests");
                        dataGridView3.Columns["NumGuests"].DataPropertyName = "NumGuests";
                        dataGridView3.Columns["NumGuests"].Width = 140;

                        dataGridView3.DataSource = dataTable;
                    }
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            // Set the license context for EPPlus
            // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Load your Excel template
            string templatePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Menu Report.xlsx";
             FileInfo templateFile = new FileInfo(templatePath);
             using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
             {
                 ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                 // Assuming your DataGrid is bound to a DataTable named "dataTable"
                 int rowIndex = 8; // Starting row index in the Excel template
                 foreach (DataGridViewRow row in dataGridView1.Rows)
                 {

                     // Check if the cell value is not null before accessing it
                     if (row.Cells[0].Value != null)
                     {
                         // Assuming column 0 is for values in column D (1,2,3,...) and column 1 is for values in column E (9.99,7.99,...)
                         worksheet.Cells[rowIndex, 4].Value = row.Cells[0].Value.ToString(); // Column D
                     }

                     if (row.Cells[1].Value != null)
                     {
                         worksheet.Cells[rowIndex, 5].Value = row.Cells[3].Value.ToString(); // Column E
                     }
                     rowIndex++;
                 }

                 // Save the Excel file
                 string savePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Menu Report Exported.xlsx";
                 FileInfo saveFile = new FileInfo(savePath);
                 excelPackage.SaveAs(saveFile);
             }

             MessageBox.Show("Export successful! The file saved as Menu Report Exported.xlsx");
         }

            // This method populates the DataGrid with sample data for testing
            private void PopulateDataGrid()
            {
                // Clear existing data
                dataGridView1.Rows.Clear();

                // Add sample data to the DataGrid
                for (int i = 1; i <= 10; i++)
                {
                    dataGridView1.Rows.Add(i, (11 - i) * 2 + 7.99); // Assuming these are the values from your description
                }
            }

            private void MainForm_Load(object sender, EventArgs e)
            {
                // Populate the DataGrid with sample data on form load (for testing purposes)
                PopulateDataGrid();
            }


            private void iconButton2_Click(object sender, EventArgs e)
            {      

                        // Set the license context for EPPlus
                        // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        // Load your Excel template
                        string templatePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Orders Report.xlsx";
                    FileInfo templateFile = new FileInfo(templatePath);
                    using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                        // Assuming your DataGrid is bound to a DataTable named "dataTable"
                        int rowIndex = 8; // Starting row index in the Excel template
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {

                            // Check if the cell value is not null before accessing it
                            if (row.Cells[0].Value != null)
                            {
                                worksheet.Cells[rowIndex, 4].Value = row.Cells[0].Value.ToString(); // Column D
                            }

                            if (row.Cells[1].Value != null)
                            {
                                worksheet.Cells[rowIndex, 5].Value = row.Cells[4].Value.ToString(); // Column E
                            }
                            rowIndex++;
                        }

                        // Save the Excel file
                        string savePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Orders Report Exported.xlsx";
                        FileInfo saveFile = new FileInfo(savePath);
                        excelPackage.SaveAs(saveFile);
                    }

                    MessageBox.Show("Export successful! The file saved as Orders Report Exported.xlsx");
                }

                

                private void iconButton3_Click(object sender, EventArgs e)
                {


                    
                                // Set the license context for EPPlus
                                // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                                // Load your Excel template
                                string templatePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Reservation Report.xlsx";
                        FileInfo templateFile = new FileInfo(templatePath);
                        using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                            // Assuming your DataGrid is bound to a DataTable named "dataTable"
                            int rowIndex = 8; // Starting row index in the Excel template
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {

                                // Check if the cell value is not null before accessing it
                                if (row.Cells[0].Value != null)
                                {
                                    worksheet.Cells[rowIndex, 4].Value = row.Cells[0].Value.ToString(); // Column D
                                }

                                if (row.Cells[1].Value != null)
                                {
                                    worksheet.Cells[rowIndex, 5].Value = row.Cells[5].Value.ToString(); // Column E
                                }
                                rowIndex++;
                            }

                            // Save the Excel file
                            string savePath = @"C:\Users\Ronald Dela Cruz\Desktop\Reports\Reservation Report Exported.xlsx";
                            FileInfo saveFile = new FileInfo(savePath);
                            excelPackage.SaveAs(saveFile);
                        }

                        MessageBox.Show("Export successful! The file saved as Reservation Report Exported.xlsx");
                    }

                    


                    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                    {

                    }

                    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
                    {

                    }

                    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
                    {

                    }

                    


        }
}


