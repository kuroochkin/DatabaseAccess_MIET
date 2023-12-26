using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DatabaseAccess_MIET
{
    public partial class ParametrForm : Form
    {
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\proga\LR7.accdb";

        private string _baseQuery;

        public ParametrForm(string baseQuery)
        {
            InitializeComponent();
            _baseQuery = baseQuery;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем параметр из текстового поля
                string parameterValue = ParametrTextBox.Text;

                // Очищаем ListView перед выполнением нового запроса
                listView1.Clear();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = $"{_baseQuery} '{parameterValue}'";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {

                            listView1.Items.Clear();
                            listView1.Columns.Clear();
                            listView1.View = View.Details;

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                listView1.Columns.Add(reader.GetName(i), 120); // 120 - ширина колонки
                            }

                            // Добавь данные в ListView
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader[0].ToString());

                                for (int i = 1; i < reader.FieldCount; i++)
                                {
                                    item.SubItems.Add(reader[i].ToString());
                                }

                                listView1.Items.Add(item);
                            }
                        }

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
    }
}
