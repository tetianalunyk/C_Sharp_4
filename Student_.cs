using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student : Person
    {
        private Education _osvita;
        private int _group;
        private List<Exam> _exams;
        private List<Test> _credits;

        public Student() : base()
        {
            _osvita = Education.Bachelor;
            _group = 0;
            _exams = new List<Exam>();
            _credits = new List<Test>();
        }

        public Student(Person person, Education osv, int gr, List<Test> testList, List<Exam> ExamList) : base(person._name, person._surname, person.Date)
        {
            _osvita = osv;
            _group = gr;
            _exams = ExamList;
            _credits = testList;
        }

        public Education _educ
        {
            get { return _osvita; }
            set { _osvita = value; }
        }

        public int group
        {
            get { return _group; }
            set {
                if (value <= 100 || value > 699)
                {
                    throw new Exception("Group should be more then 100 and less then 699");
                }
                _group = value;
            }
        }

        public List<Exam> _Exam
        {
            get { return _exams; }
            set { _exams = value; }
        }

        public List<Test> _Test
        {
            get { return _credits; }
            set { _credits = value; }
        }

        public double GetEverage
        {
            get {
                if (_exams.Count == 0) return 0;
                double sum = 0;
                foreach (Exam ex in _exams)
                    sum += ex.mark;
                return sum / _exams.Count;
            }
        }

        public bool this[Education value]
        {
            get
            {
                return _osvita == value;
                
            }
        }

        public void AddExams(Exam[] exams)
        {
            _exams.AddRange(exams);
        }

        public void AddCredits(Test[] test)
        {
            _credits.AddRange(test);
        }

        public override string ToString()
        {
            string temp_exam = "";
            PersonBase.ToString();
            string temp_credit = "";
            for (int i = 0; i < _exams.Count; i++) temp_exam += _exams[i].ToString() + "\r\n";
            for (int i = 0; i < _credits.Count; i++) temp_credit += _credits[i].ToString() + "\r\n";
            return "Education: " + _osvita + "\nGroup: " + _group + "\nExams: " + temp_exam + "\nCredit: " + temp_credit + "Average mark: " + GetEverage;
        }

        public virtual string ToShortString()
        {
            return $"Education: {_osvita} Group: {_group} Marks: {GetEverage}";
        }

        public IEnumerable<Exam> GetExamsMoreThen(int _mark)
        {
            foreach (Exam ex in _exams)
            {
                if (ex.mark > _mark)
                    yield return ex;
            }
        }

        public IEnumerable GetSesia()
        {
            foreach (Exam ex in _exams)
            {
                yield return ex;
            }
            foreach (Test tes in _credits)
            {
                yield return tes;
            }
        }

        public Person PersonBase
        {
            get { return new Person(Name, Surname, DateOfBirth); }
            set
            {
                Name = value._name;
                Surname = value._surname;
                DateOfBirth = value._dateOfBirth;
            }
        }

        public override object DeepCopy()
        {
            Student other = new Student(this.PersonBase, this._osvita, this._group, new List<Test>(), new List<Exam>());
            foreach (Exam ex in _Exam)
                other._exams.Add(ex.DeepCopy() as Exam);
            return other;
        }
    }
}
