using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person: IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string Name;
        protected string Surname;
        protected DateTime DateOfBirth;
        public Person(string _name, string _surname, DateTime _data)
        {
            Name = _name;
            Surname = _surname;
            DateOfBirth = _data;
        }
        public Person()
        {
            Name = "NoName";
            Surname = "Nobody";
            DateOfBirth = new DateTime(2000, 01, 01);
        }
        public string _name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string _surname
        {
            get { return Surname; }
            set { Surname = value; }
        }
        public DateTime _dateOfBirth
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }
        public int _year
        {
            get { return this.DateOfBirth.Year; }
            set { DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day); }
        }
        public override string ToString()
        {
            return $"Name: {Name} \nSurname: {Surname} \nDate_of_Birth: {DateOfBirth}\n";
        }
        public virtual string ToShortString()
        {
            return $"Name: {Name} Surname: {Surname}";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Person person = (Person)obj;
            return (this.Name == person.Name && this.Surname == person.Surname && this.DateOfBirth == person.DateOfBirth);
        }

        public static bool operator ==(Person left, Person right)
        {
            if  ((left.DateOfBirth != right.DateOfBirth) && (left.Name != right.Name) && (left.Surname != right.Surname)) return false;
            return true;
        }

        public static bool operator !=(Person left, Person right)
        {
            return (left.DateOfBirth == right.DateOfBirth) && (left.Name == right.Name) && (left.Surname == right.Surname) ? false : true;
        }

        public override int GetHashCode()
        {
            int hash = 10;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Surname) ? Surname.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, DateOfBirth) ? DateOfBirth.GetHashCode() : 0);
            return hash;

        }

        public virtual object DeepCopy()
        {
            Person person = new Person(this.Name, this.Surname, this.DateOfBirth);
            return person;
        }
    

        public DateTime Date
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }

        public int CompareTo(object o)
        {
                return _surname.CompareTo((o as Person)._surname);
        }

        public int Compare(Person x, Person y)
        {
            return x.Date.CompareTo(y.Date);
            /*if (x.Date.DayOfYear.CompareTo(y.Date.DayOfYear) != 0)
            {
                return x.Date.DayOfYear.CompareTo(y.Date.DayOfYear);
            }
            else if (x.Date.DayOfWeek.CompareTo(y.Date.DayOfWeek) != 0)
            {
                return x.Date.DayOfWeek.CompareTo(y.Date.DayOfWeek);
            }
            else if (x.Date.Day.CompareTo(y.Date.Day) != 0)
            {
                return x.Date.Day.CompareTo(y.Date.Day);
            }
            else
            {
                return 0;
            }*/
        }
    }
}
