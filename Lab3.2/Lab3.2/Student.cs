using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Lab3._2
{
    public class Student : INotifyPropertyChanged
    {
        public enum StudentType
        {
            Bachelour, Magistr
        }

        private string _firstName = "BEST";
        private int _group;
        private short _course;
        private double _averageMarks;
        private StudentType _studentType;
        private bool _active;


        [DisplayName("Имя")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Trim().Length == 0) throw new Exception("Name can't be empty");
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        [DisplayName("Группа")]
        public int Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        [DisplayName("Курс обучения")]
        public short Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }
        [DisplayName("Средний балл")]
        public double AverageMarks
        {
            get => _averageMarks;
            set
            {
                _averageMarks = value;
                OnPropertyChanged(nameof(AverageMarks));
            }
        }
        

        [Browsable(false)]
        [JsonIgnore]
        public int IntAverageMarks
        { 
            get => (int)(AverageMarks * 100);
            set => AverageMarks = value / 100.0;
        }

        [DisplayName("Статус")]
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }
        [DisplayName("Степень обучения")]
        public StudentType Type
        {
            get => _studentType;
            set
            {
                _studentType = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public int IntType
        {
            get => (int)Type;
            set => Type = (StudentType)value;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Student Clone() => new Student() 
        {
                FirstName = this.FirstName,
                Group = this.Group,
                Active= this.Active,
                AverageMarks = this.AverageMarks,
                Type = this.Type,
                Course = this.Course
        };
    }
}
