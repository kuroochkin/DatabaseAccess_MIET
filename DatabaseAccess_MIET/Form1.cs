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

        //Группы
        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Группы";
        }

        //Предметы
        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Предмет";
        }

        //Семестры
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Семестр";
        }

        //Студенты
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Студенты";
        }

        //Текущая успеваемость
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Текущая успеваемость";
        }

        //Факультеты
        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _сurrentTable = "Факультеты";
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

        //Количество студентов во всех группах
        private void button13_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Количество студентов во всех группах]";
            DrawProcedure(query);
        }

        //Среднее количество недель в каждом семестре
        private void button14_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Средние количество недель в каждом семестре]";
            DrawProcedure(query);
        }

        //Факультеты [Полноя имя] - [Короткое имя]
        private void button15_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Факультеты Запрос]";
            DrawProcedure(query);
        }

        //Добавление группы 4587
        private void button16_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Добавление группы 4587]";
            DrawProcedure(query);

            MessageBox.Show($"Группа 4587 успешно добавлена");
        }

        //Обновление проживания для девушек
        private void button17_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Обновление проживания для девушек]";
            DrawProcedure(query);

            MessageBox.Show($"Теперь девушки не живут в общежитии");
        }

        // Удаление студентов женского пола
        private void button18_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Удаление студентов женского пола";
            DrawProcedure(query);

            MessageBox.Show($"Теперь студентов женского пола нет");
        }

        //Запрос с параметром пола у студентов
        private void button19_Click(object sender, EventArgs e)
        {
            string query = "EXEC [Выбор студента по полу]";
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
            string query = "SELECT * FROM Группы WHERE НомерГруппы =";
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

