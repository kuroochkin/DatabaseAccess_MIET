using System.Data.OleDb;
using System.Data;
using System.ComponentModel.Design;

namespace DatabaseAccess_MIET
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView;

        public Form1()
        {
            InitializeComponent();
            button11.Click += OpenAddFormButton_Click;
            button12.Click += OpenUpdateFormButton_Click;

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true
            };
        }

        private string _сurrentTable = "";

        // Получить данные таблицы по имени таблицы
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Get_Tables(_сurrentTable);
        }

        //Факультет
        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Факультет";
        }

        //Виды родственников
        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Виды родственников";
        }

        //Группа
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Группа";
        }

        //Студенты
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Студенты";
        }

        //Льгота
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Льгота";
        }

        //Родственники студентов
        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Родственники студентов";
        }

        //Льгота_Студент
        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Льгота_Студент";
        }

        //Родственник_Студент
        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Родственник_Студент";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
        }

        private void OpenButton11(object sender, EventArgs e)
        {
            button11.Enabled = true;
        }

        private void OpenButton12(object sender, EventArgs e)
        {
            button12.Enabled = true;
        }

        //Удаление строки из таблицы
        private void button10_Click(object sender, EventArgs e)
        {
            var _parametrForm = new DeleteForm(_сurrentTable);
            _parametrForm.Show();
        }

        //Новая форма для добавления записи в таблицу
        private void OpenAddFormButton_Click(object sender, EventArgs e)
        {
            // Получаем данные о колонках таблицы, чтобы понимать какие колонки заполнять
            var dataColumns = GetTableColumnsInfo(_сurrentTable);

            // Создаем форму
            var _addForm = new AddForm(dataColumns, _сurrentTable);

            //Если форма закрыта, делаем кнопку добавления активной
            _addForm.FormClosed += OpenButton11;

            //Показываем форму
            _addForm.Show();
        }

        //Новая форма для обновления записи в таблице
        private void OpenUpdateFormButton_Click(object sender, EventArgs e)
        {
            // Получаем данные о колонках таблицы, чтобы понимать какие колонки заполнять
            var dataColumns = GetTableColumnsInfo(_сurrentTable);

            // Создаем форму
            var _updateForm = new UpdateForm(dataColumns, _сurrentTable);

            //Если форма закрыта, делаем кнопку добавления активной
            _updateForm.FormClosed += OpenButton12;

            //Показываем форму
            _updateForm.Show();
        }

        //Количество студентов разного пола
        private void button13_Click(object sender, EventArgs e)
        {
            string query = "EXEC SQL7";
            DrawProcedure(query);
        }

        //Студенты женского пола
        private void button14_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Студенты женского пола]";
            DrawProcedure(query);
        }

        //Самый младший студент
        private void button15_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Самый младший студент]";
            DrawProcedure(query);
        }

        //Добавление дяди в виды родственников
        private void button16_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Добавление дяди в виды родственников]";
            DrawProcedure(query);

            MessageBox.Show($"Дядя добавлен в базу данных");
        }

        //Обновление названия факультета (Биохимический)
        private void button17_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Обновление названия факультета]";
            DrawProcedure(query);

            MessageBox.Show($"Факультет теперь биохимический");
        }

        // Удаление факультетов без деканата
        private void button18_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Удаление факультетов без деканата]";
            DrawProcedure(query);

            MessageBox.Show($"Факультетов без деканата теперь нет");
        }

        //Запрос с параметром пола у студентов
        private void button19_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Запрос с параметром пола у студентов]";
            var _parametrForm = new ParametrForm(query);

            _parametrForm.Show();
        }

        //Запрос с параметром фамилии студента
        private void button20_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Студенты WHERE Фамилия =";
            var _parametrForm = new ParametrForm(query);

            _parametrForm.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Группа WHERE НомерГруппы =";
            var _parametrForm = new ParametrForm(query);

            _parametrForm.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Get_Tables("MSysObjects");
        }
    }
}

