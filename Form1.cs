using System;
using System.Data;
using System.Text;
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
        public DataChanger(string login, string password, string server, string database, string table)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            user = login;
            this.password = password;
            this.server = server;
            this.database = database;
            this.table = table;
            init();
        }
        private BindingSource bindingSource1 = new BindingSource();
        private MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

        private string table;
        private string database;
        private string user;
        private string password;
        private string server;

        public DataChanger()
        {
            try
            {
                string[] config = File.ReadAllLines(Environment.CurrentDirectory + "\\config.txt");
                server = config[0];
                database = config[1];
                table = config[2];
                user = config[3];
                password = config[4];
            } catch (Exception)
            {
                MessageBox.Show("Error occurred. Please, check the config.txt which must be located in the current folder.\nIt Must contain 5 rows one by one :\nserver\ndatabase\ntable\nuser\npassword");
                Environment.Exit(1);
            }
            init();
            
        }

        private void handleDataError(object sender, EventArgs e)
        {
            GetData("SELECT * FROM " + table);
        }

        private void init()
        {
            InitializeComponent();
            submitButton.Click += new EventHandler(SubmitButton_Click);
            lastName.TextChanged += new EventHandler(Reload_With_Filters);
            areaFrom.ValueChanged += new EventHandler(Reload_With_Filters);
            areaTo.ValueChanged += new EventHandler(Reload_With_Filters);
            enabledFilterByArea.CheckStateChanged += new EventHandler(Reload_With_Filters);
            strictSearchByName.CheckStateChanged += new EventHandler(Reload_With_Filters);
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(handleDataError);
            Load += new EventHandler(Form1_Load);
            Text = "Areas viewer";
        }

        private void GetData(string selectCommand)
        {
            try
            {
                String connectionString = "server=" + server + ";user=" + user + ";database=" + database + ";password=" + password;
                dataAdapter = new MySqlDataAdapter(selectCommand, connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                try
                {
                    dataAdapter.Fill(table);
                } catch (Exception)
                {
                    MessageBox.Show("Please, check your credentials again.\nAlso review the config.txt");
                    Application.Exit();
                }
                bindingSource1.DataSource = table;
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
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT * FROM " + table);
        }

        private void Reload_With_Filters(object sender, EventArgs e)
        {
            string select = "SELECT * FROM " + table + " WHERE TRUE";
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
            try
            {
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
            } catch (Exception)
            {
                MessageBox.Show("Перевірте правильність введених даних");
            }
        }

        private void saveData_Click(object sender, EventArgs e)
        {
            Reload_With_Filters(null, null);
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == null || saveFileDialog1.FileName.Trim().Equals(""))
            {
                return;
            }
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
            paragraph = document.Paragraphs.Add();
            int amOfRecords = 0;
            foreach (DataRow row in table.Rows)
            {
                stringBuilder.Append(" [Address]: " + row["address", DataRowVersion.Current].ToString());
                stringBuilder.Append(" [Owner]: " + row["owner", DataRowVersion.Current].ToString());
                stringBuilder.Append(" [Area]: " + row["area", DataRowVersion.Current].ToString() + "(м^2)\n");
                amOfRecords++;
            }
            paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = stringBuilder.ToString();
            paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = "The total number of records that satisfy the filter above is " + amOfRecords; 
            document.SaveAs2(saveFileDialog1.FileName);
            document.Close();
            app.Quit();
        }
    }
}