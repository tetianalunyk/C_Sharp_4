using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string TypeOfChanges { get; set; }
        public Student Student { get; set; }

        public StudentListHandlerEventArgs(string collname, string type, Student student)
        {
            CollectionName = collname;
            TypeOfChanges = type;
            Student = student;
        }

        public override string ToString()
        {
            return $"Collection Name: {CollectionName}; Type of Changes:{TypeOfChanges} \n {Student.ToString()}\n";
        }
    }
}
