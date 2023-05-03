using System.ComponentModel;

namespace Lab3._2
{
    public partial class EditForm : Form
    {
        private Student student;
        public EditForm(Student st)
        {
            student = st;
            InitializeComponent();
            //nameof - получение имени элемента
            foreach (var type in Enum.GetNames<Student.StudentType>())
            {
                combType.Items.Add(type);
            }
            //FirstName
            var bndName = txtFName.DataBindings.Add(nameof(TextBox.Text), st, nameof(Student.FirstName));
            //Вкл поддержки для форматирования данных
            bndName.FormattingEnabled = true;
            bndName.DataSourceUpdateMode = DataSourceUpdateMode.Never;

            //Group
            numGrp.DataBindings.Add(nameof(TextBox.Text), st, nameof(Student.Group));
            
            //Course
            numCrs.DataBindings.Add(nameof(NumericUpDown.Value), st, nameof(Student.Course));
            //AvrgMarks
            var bndAvrMrk = trkAvMrk.DataBindings.Add(nameof(TrackBar.Value), st, nameof(Student.IntAverageMarks));
            bndAvrMrk.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            student.PropertyChanged += Student_PropertyChanged;
            //Active
            chAct.DataBindings.Add(nameof(RadioButton.Checked), st, nameof(Student.Active));
            //Type
            combType.DataBindings.Add(nameof(ComboBox.SelectedIndex), st, nameof(Student.IntType));

            lblAvMrk.Text = $"Средний балл: {student.AverageMarks}";
        }

        private void Student_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            lblAvMrk.Text = $"Средний балл: {student.AverageMarks}";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                student.FirstName = txtFName.Text;
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                txtFName.BackColor = Color.DarkOrchid;
                txtFName.Focus();
                MessageBox.Show(ex.Message ?? "ERROR", "Wops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            txtFName.BackColor = Color.White;
        }

    }
}
