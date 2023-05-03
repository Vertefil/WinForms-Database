using System.ComponentModel;
using System.Text.Json;

namespace Lab3._2
{
    public partial class Form1 : Form
    {
        private BindingList<Student> _students = new();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = _students;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Сохранение всего списка в файл
            using (FileStream fs = new("dataList.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, _students);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Считываем инфу с файла
            using (FileStream fs = new FileStream("dataList.json", FileMode.Open))
            {
                var data = JsonSerializer.Deserialize<BindingList<Student>>(fs);
                if (data != null)
                {
                    foreach (var student in data)
                    {
                        _students.Add(student);
                    }
                }
            }
        }

        

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student();
            newStudent.AverageMarks = 3.33;
            newStudent.Course = 1;
            newStudent.Group = 1;

            EditForm ef = new(newStudent);
            if (ef.ShowDialog(this) == DialogResult.OK) _students.Add(newStudent);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var currentRow = (dataGridView1.SelectedRows[0].Index);
                var tmpSt = _students[(int)currentRow].Clone();
                EditForm ef = new(tmpSt);
                if (ef.ShowDialog(this) == DialogResult.OK) _students[(int)currentRow] = tmpSt;
            }
            else
            {
                MessageBox.Show("No data selected",
                    "Heh...\nNot funny",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var toDel = dataGridView1.SelectedRows[0].Index;
                _students.RemoveAt(toDel);
            }
            catch
            {
                MessageBox.Show("No data selected",
                    "Heh...\nNot funny",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reference refer = new Reference();
            refer.ShowDialog();
        }
    }
}
