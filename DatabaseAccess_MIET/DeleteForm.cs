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
using System.Xml;

namespace DatabaseAccess_MIET
{
    public partial class DeleteForm : Form
    {
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\proga\LR7.accdb";

        private string _nameTable;
        public DeleteForm(string nameTable)
        {
            InitializeComponent();
            _nameTable = nameTable;
        }

        //Кнопка удаления
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string parameterValue = DeleteIdTextBox.Text;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand())
                    {
                        // Создаем SQL-запрос для удаления строки
                        command.Connection = connection;
                        command.CommandText = $"DELETE FROM {_nameTable} WHERE ИД = '{parameterValue}'";

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Строка успешно удалена");
                        }
                        else
                        {
                            MessageBox.Show("Строка не найдена");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении строки: {ex.Message}");
            }

        }
    }
}
