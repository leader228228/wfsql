using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using MetroFramework.Forms;

namespace wfsql
{
    public partial class DataChanger : MetroForm
    {
        private BindingSource bindingSource1 = new BindingSource();
        private MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        private string TABLE_NAME = "areas";
        private string DATABASE_NAME = "tspp_var_11";
        public DataChanger()
        {
            InitializeComponent();
            submitButton.Click += new EventHandler(SubmitButton_Click);
            lastName.TextChanged += new EventHandler(Reload_With_Filters);
            areaFrom.ValueChanged += new EventHandler(Reload_With_Filters);
            areaTo.ValueChanged += new EventHandler(Reload_With_Filters);
            enabledFilterByArea.CheckStateChanged += new EventHandler(Reload_With_Filters);
            strictSearchByName.CheckStateChanged += new EventHandler(Reload_With_Filters);

            Load += new EventHandler(Form1_Load);
            Text = "DataGridView data binding and updating demo";

        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.  
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString = "server=93.79.11.69;user=root;database=" + DATABASE_NAME + ";password=tspp11";

                // Create a new data adapter based on the specified query.
                dataAdapter = new MySqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.GetType().ToString() + " occurred: " + e.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT * FROM " + TABLE_NAME);
        }

        private void Reload_With_Filters(object sender, EventArgs e)
        {
            string select = "SELECT * FROM " + TABLE_NAME + " WHERE TRUE";
            if (enabledFilterByArea.Checked)
            {
                select = select + (" AND area >= " + areaFrom.Value + " AND area <= " + areaTo.Value);
            }
            if (enabledFilterByName.Checked)
            {
                if (strictSearchByName.Checked)
                {
                    select = select + (" AND owner = '" + (lastName.Text == null ? "" : lastName.Text) + "'");
                } else
                {
                    select = select + (" AND REGEXP_LIKE(owner, '^" + (lastName.Text == null ? "" : lastName.Text) + "')");
                }
            }
            GetData(select);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void saveData_Click(object sender, EventArgs e)
        {
            Reload_With_Filters(null, null);
            saveFileDialog1.ShowDialog();
            BindingSource binding = (BindingSource)dataGridView1.DataSource;
            DataTable table = (DataTable)binding.DataSource;
            StringBuilder stringBuilder = new StringBuilder();
            Word.Application app = new Word.Application();
            Word.Document document;
            if (File.Exists(saveFileDialog1.FileName))
            {
                document = app.Documents.Add(saveFileDialog1.FileName);
            }
            else
            {
                document = app.Documents.Add();
            }
            Word.Paragraph paragraph;
            foreach (DataRow row in table.Rows)
            {
                stringBuilder.Append(" [Address]: " + row["address", DataRowVersion.Current].ToString());
                stringBuilder.Append(" [Owner]: " + row["owner", DataRowVersion.Current].ToString());
                stringBuilder.Append(" [Area]: " + row["area", DataRowVersion.Current].ToString() + "(м^2)\n");
            }
            paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = stringBuilder.ToString();
            document.SaveAs2(saveFileDialog1.FileName);
            document.Close();
            app.Quit();
            /*
            try
            {
                Reload_With_Filters(null, null);
                saveFileDialog1.ShowDialog();
                BindingSource binding = (BindingSource) dataGridView1.DataSource;
                DataTable table = (DataTable)binding.DataSource;
                StringBuilder stringBuilder = new StringBuilder();
                Word.Application app = new Word.Application();
                Word.Document document;
                if (File.Exists(saveFileDialog1.FileName))
                {
                    document = app.Documents.Add(saveFileDialog1.FileName);
                }
                else
                {
                    document = app.Documents.Add();
                }
                foreach (DataRow row in table.Rows)
                {
                    stringBuilder.Append(" Address: " + row["address", DataRowVersion.Current].ToString());
                    stringBuilder.Append(" Owner: " + row["owner", DataRowVersion.Current].ToString());
                    stringBuilder.Append(" Area: " + row["area", DataRowVersion.Current].ToString());
                    document.Paragraphs.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
                document.SaveAs2(saveFileDialog1.FileName);
                document.Close();
                app.Quit();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " occurred: " + ex.Message);
            }*/
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void enabledFilterByArea_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}