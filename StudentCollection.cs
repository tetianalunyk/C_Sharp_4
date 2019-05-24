using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    class StudentCollection
    {
        public string CollectionName { get; set; }
        public event StudentListHandler StudentCountChanged;
        public event StudentListHandler StudentReferenceChanged;

        private List<Student> students;
        public List<Student> Students
        {
            get => students;
            set => students = value;
        }

        public void AddDefaults()
        {
            Students = new List<Student>()
                {
                    new Student(new Person("Tetiana", "Lunyk", new DateTime(1999, 09, 24)),
                           Education.Bachelor, 311,
                           new List<Test> { new Test("Java", true)},
                           new List<Exam> { new Exam("Programming", 1, new DateTime(2015, 10, 24))}),
                    new Student(new Person("Tetiana", "Fesh", new DateTime(2000, 06, 24)),
                           Education.Bachelor, 311,
                           new List<Test> { new Test("Java", true)},
                           new List<Exam> { new Exam("Programming", 2, new DateTime(2015, 10, 24))}),
                    new Student(new Person("Albert", "Einstein", new DateTime(1989, 09, 24)),
                           Education.Bachelor, 311,
                           new List<Test> { new Test("Java", true)},
                           new List<Exam> { new Exam("Programming", 3, new DateTime(2015, 10, 24))})
                };
            foreach (var student in Students)
            {
                StudentCountChanged(this, new StudentListHandlerEventArgs(CollectionName, "Added", student));
            }
        }

        public void AddStudents(params Student[] range)
        {
            students = new List<Student>();
            foreach(var stud in range)
            {
               students.Add(stud);
            }
            foreach (var student in students)
                StudentCountChanged(this, new StudentListHandlerEventArgs(CollectionName, "Added", student));
        }

        public void Remove(int j)
        {
            if (j >= 0 && j <= Students.Count - 1)
            {
                Student DeletedStudent = Students[j];
                Students.RemoveAt(j);
                StudentCountChanged(this, new StudentListHandlerEventArgs(CollectionName, "Removed", DeletedStudent));
            }
        }

        public Student this[int i]
        {
            get { return Students[i]; }
            set
            {
                Students[i] = value;
                StudentReferenceChanged(this, new StudentListHandlerEventArgs(CollectionName, "Changed", Students[i]));
            }
        }

        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < students.Count; i++)
                temp += "\nName " + students[i]._name + "\nSurname " + students[i]._surname + "\nDate of birth: " + students[i]._dateOfBirth + students[i].ToString() + "\r\n";
            return "Students: " + temp;
        }

        public virtual string ToShortString()
        {
            string temp = "";
            for (int i = 0; i < students.Count; i++)
                temp += "\nName: " + students[i]._name + "\nSurname: " + students[i]._surname + "\nDate of Birth: " + students[i]._dateOfBirth +"\nEducation: "+ students[i]._educ +"\nGroup: "+ students[i].group + "\nCount exams: "+ students[i]._Exam.Count + "\nEveradge: " + students[i].GetEverage + "\nCount tests: " + students[i]._Test.Count + "\r\n";
            return "Students: " + temp;
        }

        public void SortBySurname() => students.Sort();// (x,y) => x.CompareTo(y));
        

        public void SortByDate()
        {
            students.Sort((x, y) => new Student().Compare(x,y));
        }

        public void SortByEverage()
        {
            students.Sort((x, y) => new AverageMarkComparer().Compare(x, y));
        }

        public double GetMaxEvarage()
        {
            return students.Count != 0 ? students.Select(x => x.GetEverage).Max() : 0;
        }

        public List<Student> EvarageMarkGroup(double value)
        {
            return students.Where(x => Math.Abs(x.GetEverage - value)<0.001).ToList();
        }

        public IEnumerable<Student> GetListOfMasters()
        {
            return students.Where(x => x._educ == Education.Master);
        }


    }
}
