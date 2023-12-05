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
    public partial class UpdateForm : Form
    {
        //Прокидываем имя таблицы в форму
        private string _nameTable = string.Empty;

        //Имеем ссылку на информацию о колонках таблицы
        private DataTable _columnsInfo;

        TableLayoutPanel tableLayoutPanel;

        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\proga\StudentsAccessDB.accdb";

        public UpdateForm(DataTable columnsInfo, string nameTable)
        {
            InitializeComponent();
            _nameTable = nameTable;
            _columnsInfo = columnsInfo;

            InitializeControls();
        }

        private void InitializeControls()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoSize = true
            };

            // Добавление TextBox для ввода Id
            tableLayoutPanel.Controls.Add(new Label { Text = "ID", TextAlign = ContentAlignment.MiddleRight }, 0, tableLayoutPanel.RowCount - 1);
            TextBox idTextBox = new TextBox { Dock = DockStyle.Fill, Tag = "ID" };
            tableLayoutPanel.Controls.Add(idTextBox, 1, tableLayoutPanel.RowCount - 1);

            // Добавление TextBox для каждой колонки
            foreach (DataRow row in _columnsInfo.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();

                tableLayoutPanel.Controls.Add(new Label { Text = columnName, TextAlign = ContentAlignment.MiddleRight }, 0, tableLayoutPanel.RowCount - 1);

                TextBox textBox = new TextBox { Dock = DockStyle.Fill, Tag = columnName };
                tableLayoutPanel.Controls.Add(textBox, 1, tableLayoutPanel.RowCount - 1);
            }

            Controls.Add(tableLayoutPanel);

            Button updateButton = new Button
            {
                Text = "Обновить",
                Dock = DockStyle.Top
            };
            updateButton.Click += UpdateButton_Click;
            Controls.Add(updateButton);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем Id из соответствующего TextBox
                TextBox idTextBox = tableLayoutPanel.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag?.ToString() == "ID");
                string recordId = idTextBox?.Text;

                if(recordId is null)
                    throw new NullReferenceException(nameof(recordId));

                LoadData(recordId);

                // Проверяем, что Id не пусто
                if (!string.IsNullOrEmpty(recordId))
                {
                    // Формируем строку SET для обновления значений столбцов
                    string updateValues = string.Join(", ", _columnsInfo.Rows.OfType<DataRow>().Select(row =>
                    {
                        string columnName = row["COLUMN_NAME"].ToString();

                        TextBox textBox = tableLayoutPanel.Controls.OfType<TextBox>().FirstOrDefault(ctrl => ctrl.Tag?.ToString() == columnName);
                        string text = textBox?.Text ?? "NULL";

                        Console.WriteLine($"Column: {columnName}, Value: {text}");

                        return $"{columnName} = '{text}'";
                    }));

                    // Формируем условие WHERE
                    string condition = $"ИД = '{recordId}'";

                    // Запрос на обновление данных в БД, прокидываем condition
                    string query = $"UPDATE {_nameTable} SET {updateValues} WHERE {condition}";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Данные успешно обновлены в таблице");
                            }
                            else
                            {
                                MessageBox.Show("Не удалось обновить данные в таблице");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректное значение для ИД");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
            }
        }

        private void LoadData(string recordId)
        {
            try
            {
                string query = $"SELECT * FROM {_nameTable} WHERE ИД = '{recordId}'";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Устанавливаем значения в TextBox'ы
                                foreach (DataRow row in _columnsInfo.Rows)
                                {
                                    string columnName = row["COLUMN_NAME"].ToString();
                                    TextBox textBox = tableLayoutPanel.Controls.OfType<TextBox>().FirstOrDefault(ctrl => ctrl.Tag?.ToString() == columnName);

                                    if (textBox != null)
                                    {
                                        textBox.Text = reader[columnName].ToString();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    } 
}
