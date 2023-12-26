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
    public partial class AddForm : Form
    {
        //Прокидываем имя таблицы в форму
        private string _nameTable = string.Empty;

        //Имеем ссылку на информацию о колонках таблицы
        private DataTable _columnsInfo;

        TableLayoutPanel tableLayoutPanel;

        public AddForm(DataTable columnsInfo, string nameTable)
        {
            InitializeComponent(columnsInfo);
            _nameTable = nameTable;
            _columnsInfo = columnsInfo;
        }

        private void InitializeComponent(DataTable columnsInfo)
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoSize = true
            };

            // Добавление TextBox для каждой колонки
            foreach (DataRow row in columnsInfo.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();

                tableLayoutPanel.Controls.Add(new Label { Text = columnName, TextAlign = ContentAlignment.MiddleRight }, 
                    0, tableLayoutPanel.RowCount - 1);

                TextBox textBox = new TextBox { Dock = DockStyle.Fill, Tag = columnName };
                tableLayoutPanel.Controls.Add(textBox, 1, tableLayoutPanel.RowCount - 1);
            }

            // Добавление элементов на форму
            Controls.Add(tableLayoutPanel);

            Button addButton = new Button
            {
                Text = "Добавить",
                Dock = DockStyle.Top
            };

            //Вызываем обработку добавления записи в БД
            addButton.Click += AddButton_Click;
            Controls.Add(addButton);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Получаем колонки
                string columns = string.Join(", ", _columnsInfo.Rows.OfType<DataRow>().Select(row => row["COLUMN_NAME"]));

                //Получаем значения
                string values = string.Join(", ", tableLayoutPanel.Controls
                                        .OfType<TextBox>()
                                        .Select(textBox => $"'{textBox.Text}'"));

                //Запрос на добавление данных в БД
                string query = $"INSERT INTO [{_nameTable}] ({columns}) VALUES ({values})";

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\proga\LR7.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Выполнение SQL-запроса
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно добавлены в таблицу");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные в таблицу");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}, т.к. есть несоответствие типам полей");
            }
        }

    }
}
