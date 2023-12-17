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

        private string _�urrentTable = "";

        // �������� ������ ������� �� ����� �������
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Get_Tables(_�urrentTable);
        }

        //���������
        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "���������";
        }

        //���� �������������
        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "���� �������������";
        }

        //������
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "������";
        }

        //��������
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "��������";
        }

        //������
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "������";
        }

        //������������ ���������
        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "������������ ���������";
        }

        //������_�������
        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "������_�������";
        }

        //�����������_�������
        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _�urrentTable = "�����������_�������";
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

        //�������� ������ �� �������
        private void button10_Click(object sender, EventArgs e)
        {
            var _parametrForm = new DeleteForm(_�urrentTable);
            _parametrForm.Show();
        }

        //����� ����� ��� ���������� ������ � �������
        private void OpenAddFormButton_Click(object sender, EventArgs e)
        {
            // �������� ������ � �������� �������, ����� �������� ����� ������� ���������
            var dataColumns = GetTableColumnsInfo(_�urrentTable);

            // ������� �����
            var _addForm = new AddForm(dataColumns, _�urrentTable);

            //���� ����� �������, ������ ������ ���������� ��������
            _addForm.FormClosed += OpenButton11;

            //���������� �����
            _addForm.Show();
        }

        //����� ����� ��� ���������� ������ � �������
        private void OpenUpdateFormButton_Click(object sender, EventArgs e)
        {
            // �������� ������ � �������� �������, ����� �������� ����� ������� ���������
            var dataColumns = GetTableColumnsInfo(_�urrentTable);

            // ������� �����
            var _updateForm = new UpdateForm(dataColumns, _�urrentTable);

            //���� ����� �������, ������ ������ ���������� ��������
            _updateForm.FormClosed += OpenButton12;

            //���������� �����
            _updateForm.Show();
        }

        //���������� ��������� ������� ����
        private void button13_Click(object sender, EventArgs e)
        {
            string query = "EXEC SQL7";
            DrawProcedure(query);
        }

        //�������� �������� ����
        private void button14_Click(object sender, EventArgs e)
        {
            string query = "EXEC [�������� �������� ����]";
            DrawProcedure(query);
        }

        //����� ������� �������
        private void button15_Click(object sender, EventArgs e)
        {
            string query = "EXEC [����� ������� �������]";
            DrawProcedure(query);
        }

        //���������� ���� � ���� �������������
        private void button16_Click(object sender, EventArgs e)
        {
            string query = "EXEC [���������� ���� � ���� �������������]";
            DrawProcedure(query);

            MessageBox.Show($"���� �������� � ���� ������");
        }

        //���������� �������� ���������� (�������������)
        private void button17_Click(object sender, EventArgs e)
        {
            string query = "EXEC [���������� �������� ����������]";
            DrawProcedure(query);

            MessageBox.Show($"��������� ������ �������������");
        }

        // �������� ����������� ��� ��������
        private void button18_Click(object sender, EventArgs e)
        {
            string query = "EXEC [�������� ����������� ��� ��������]";
            DrawProcedure(query);

            MessageBox.Show($"����������� ��� �������� ������ ���");
        }

        //������ � ���������� ���� � ���������
        private void button19_Click(object sender, EventArgs e)
        {
            string query = "EXEC [������ � ���������� ���� � ���������]";
            var _parametrForm = new ParametrForm(query);

            _parametrForm.Show();
        }

        //������ � ���������� ������� ��������
        private void button20_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM �������� WHERE ������� =";
            var _parametrForm = new ParametrForm(query);

            _parametrForm.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ������ WHERE ����������� =";
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

