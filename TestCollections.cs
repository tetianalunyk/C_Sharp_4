using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestCollections
    {
        private List<Person> Persons { get; set; }
        private List<string> Text { get; set; }
        private Dictionary<Person, Student> PeStDictionary { get; set; }
        private Dictionary<string, Student> StStDictionary { get; set; }

        public static Student GetStudent(int index)
        {
            Student student = new Student(
                   new Person("Name" + index, "Surname" + index, DateTime.Today.AddDays(-1 * index)),
                   Education.Master, (index % 5) * 100 + index,
                   new List<Test>
                   {
                       new Test("test"+index, index%2==0 ? true : false),
                       new Test("test"+index+1, (index+1)%2==0 ? true : false),
                       new Test("test"+index+2, (index+2)%2==0 ? true : false)
                   },
                   new List<Exam>
                   {
                       new Exam("exam"+index, index%5, DateTime.Today.AddDays(-1*index+1)),
                       new Exam("exam"+index+1, (index+1)%5, DateTime.Today.AddDays(-1*index+2)),
                       new Exam("exam"+index+2, (index+2)%5, DateTime.Today.AddDays(-1*index+3)),
                   }
                );
            return student;
        }

        public TestCollections(int count)
        {
            Persons = new List<Person>();
            Text = new List<string>();
            PeStDictionary = new Dictionary<Person, Student>();
            StStDictionary = new Dictionary<string, Student>();

            for (int i = 0; i < count; i++)
            {
                Student student = GetStudent(i);
                Person person = student.PersonBase;
                Persons.Add(person);
                Text.Add(person.ToString());
                PeStDictionary.Add(person, student);
                StStDictionary.Add(person.ToString(), student);
            }

        }

        public void MeasureTime()
        {
            int length = Persons.Count - 1;
            int[] indexes = { 0, length, length / 2, length + 1 };
            foreach (var index in indexes)
            {
                var searcherStudent = GetStudent(index);
                var searcherPerson = searcherStudent.PersonBase;

                Console.WriteLine("----------------------------");

                var start = Environment.TickCount;
                var answer = Persons.Contains(searcherPerson);
                var end = Environment.TickCount;
                Console.WriteLine("List person at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = Text.Contains(searcherPerson.ToString());
                end = Environment.TickCount;
                Console.WriteLine("List person toString at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = PeStDictionary.ContainsKey(searcherPerson);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Edition, Magazine> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = PeStDictionary.ContainsValue(searcherStudent);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Edition, Magazine> value at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = StStDictionary.ContainsKey(searcherPerson.ToString());
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Magazine> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = StStDictionary.ContainsValue(searcherStudent);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Magazine> value at index {0}: " + (end - start) + " {1}", index, answer);
            }
        }
    }
}
