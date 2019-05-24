using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public string TypeOfChanges { get; set; }
        public Student GetStudent { get; set; }

        public JournalEntry(string collname, string type, Student student)
        {
            CollectionName = collname;
            TypeOfChanges = type;
            GetStudent = student;
        }

        public override string ToString()
        {
            return $"Collection Name: {CollectionName} Type of Changes: { TypeOfChanges }\n {GetStudent.ToShortString()}";
        }
    }
}
