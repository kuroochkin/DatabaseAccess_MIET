using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace DatabaseAccess_MIET
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Строка подключения к БД
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\proga\StudentsAccessDB.accdb";

        public void Get_Tables(string nameTable)
        {
            listView1.Items.Clear();

            if (String.IsNullOrEmpty(nameTable))
            {
                MessageBox.Show("Выберите таблицу!");
                return;
            }

            string sqlQuery = $"SELECT * FROM [{nameTable}]";

            // Создать подключение к базе данных Access
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Открыть подключение
                connection.Open();

                // Создать команду для выполнения SQL-запроса
                using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                {
                    // Создать адаптер данных
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        // Создать DataTable для хранения данных
                        DataTable dataTable = new DataTable();

                        // Заполнить DataTable данными из базы данных
                        adapter.Fill(dataTable);

                        listView1.View = View.Details;

                        DataTable columnsSchema = connection.GetSchema("Columns");

                        DataRow[] columns = columnsSchema.Select($"TABLE_NAME = '{nameTable}'", "ORDINAL_POSITION ASC");

                        foreach (DataRow column in columns)
                        {
                            listView1.Columns.Add(column["COLUMN_NAME"].ToString());
                        }

                        for (int i = 0; i < listView1.Columns.Count; i++)
                        {
                            listView1.Columns[i].Width = 150;
                        }

                        // Заполнить ListView данными из DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {

                            ListViewItem item = new ListViewItem(row[0].ToString());

                            for (int i = 1; i < dataTable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }

                            listView1.Items.Add(item);
                        }
                    }
                }

                connection.Close();
            }
        }

        public void DeleteRow(string nameTable, string Id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand())
                    {
                        // Создаем SQL-запрос для удаления строки
                        command.Connection = connection;
                        command.CommandText = $"DELETE FROM {nameTable} WHERE ИД = @Id";

                        // Параметры для предотвращения SQL-инъекций
                        command.Parameters.AddWithValue("@Id", Id);

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

        public DataTable GetTableColumnsInfo(string tableName)
        {
            DataTable columnsInfo = new DataTable();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Получаем информацию о колонках таблицы
                    columnsInfo = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о колонках: {ex.Message}");
            }

            return columnsInfo;
        }

        public void DrawProcedure(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {

                            listView1.Items.Clear();
                            listView1.Columns.Clear();

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



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listView1 = new ListView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(418, 270);
            button1.Name = "button1";
            button1.Size = new Size(273, 46);
            button1.TabIndex = 0;
            button1.Text = "Вывести данные из выбранной таблицы";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(31, 31);
            listView1.Name = "listView1";
            listView1.Size = new Size(660, 223);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.Location = new Point(697, 31);
            button2.Name = "button2";
            button2.Size = new Size(164, 23);
            button2.TabIndex = 2;
            button2.Text = "Студенты";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(697, 60);
            button3.Name = "button3";
            button3.Size = new Size(164, 23);
            button3.TabIndex = 3;
            button3.Text = "Льгота\r\n";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(697, 89);
            button4.Name = "button4";
            button4.Size = new Size(164, 23);
            button4.TabIndex = 4;
            button4.Text = "Группа";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(697, 118);
            button5.Name = "button5";
            button5.Size = new Size(164, 23);
            button5.TabIndex = 5;
            button5.Text = "Факультет";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(697, 147);
            button6.Name = "button6";
            button6.Size = new Size(164, 22);
            button6.TabIndex = 6;
            button6.Text = "Виды родственников";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(697, 175);
            button7.Name = "button7";
            button7.Size = new Size(164, 23);
            button7.TabIndex = 7;
            button7.Text = "Родственники студентов";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(697, 204);
            button8.Name = "button8";
            button8.Size = new Size(164, 23);
            button8.TabIndex = 8;
            button8.Text = "Льгота_Студент";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(697, 233);
            button9.Name = "button9";
            button9.Size = new Size(164, 23);
            button9.TabIndex = 9;
            button9.Text = "Родственник_Студент";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(418, 328);
            button10.Name = "button10";
            button10.Size = new Size(273, 46);
            button10.TabIndex = 10;
            button10.Text = "Удалить строку по ИД в выбранной таблице";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(418, 386);
            button11.Name = "button11";
            button11.Size = new Size(273, 46);
            button11.TabIndex = 11;
            button11.Text = "Добавить строку в выбранной таблице";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(418, 444);
            button12.Name = "button12";
            button12.Size = new Size(273, 46);
            button12.TabIndex = 12;
            button12.Text = "Обновить данные в выбранной таблице";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(31, 270);
            button13.Name = "button13";
            button13.Size = new Size(322, 23);
            button13.TabIndex = 13;
            button13.Text = "Количество студентов разного пола";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Location = new Point(31, 299);
            button14.Name = "button14";
            button14.Size = new Size(322, 23);
            button14.TabIndex = 14;
            button14.Text = "Студенты женского пола";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(31, 328);
            button15.Name = "button15";
            button15.Size = new Size(322, 23);
            button15.TabIndex = 15;
            button15.Text = "Самый младший студент";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(31, 357);
            button16.Name = "button16";
            button16.Size = new Size(322, 23);
            button16.TabIndex = 16;
            button16.Text = "Добавление дяди в виды родственников";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(31, 386);
            button17.Name = "button17";
            button17.Size = new Size(322, 23);
            button17.TabIndex = 17;
            button17.Text = "Обновление названия факультета (Биологический)";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button18
            // 
            button18.Location = new Point(31, 415);
            button18.Name = "button18";
            button18.Size = new Size(322, 23);
            button18.TabIndex = 18;
            button18.Text = "Удаление факультетов без деканата";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button19
            // 
            button19.Location = new Point(31, 444);
            button19.Name = "button19";
            button19.Size = new Size(322, 23);
            button19.TabIndex = 19;
            button19.Text = "Запрос с параметром пола у студентов";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button20
            // 
            button20.Location = new Point(31, 474);
            button20.Name = "button20";
            button20.Size = new Size(322, 23);
            button20.TabIndex = 20;
            button20.Text = "Поиск студента по фамилии";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // button21
            // 
            button21.Location = new Point(31, 504);
            button21.Name = "button21";
            button21.Size = new Size(322, 23);
            button21.TabIndex = 21;
            button21.Text = "Поиск группы по номеру";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(880, 539);
            Controls.Add(button21);
            Controls.Add(button20);
            Controls.Add(button19);
            Controls.Add(button18);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "База данных студентов";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListView listView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
    }
}