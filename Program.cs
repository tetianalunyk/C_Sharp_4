using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            StudentCollection students1 = new StudentCollection() { CollectionName = "Collection 1" };
            StudentCollection students2 = new StudentCollection() { CollectionName = "Collection 2" };

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            students1.StudentCountChanged += journal1.JournalEventHandler;
            students1.StudentReferenceChanged += journal1.JournalEventHandler;

            students2.StudentCountChanged += journal1.JournalEventHandler;
            students2.StudentCountChanged += journal2.JournalEventHandler;
            students2.StudentReferenceChanged += journal1.JournalEventHandler;
            students2.StudentReferenceChanged += journal2.JournalEventHandler;

            students1.AddDefaults();
            students2.AddDefaults();

            Console.WriteLine(students1.ToString());

            Console.WriteLine("_________________________________________________________");

            students1.Remove(1);
            students2.Remove(1);

            Console.WriteLine(students1.ToString());

            Console.WriteLine("_________________________________________________________");

            students2[0]._surname = "Tixon";

            Student newStudent = new Student();
            newStudent._surname = "Hewton";
            students2[1] = newStudent;

            Console.WriteLine(journal1.ToString());
            Console.WriteLine(journal2.ToString());
        }
    }
}
