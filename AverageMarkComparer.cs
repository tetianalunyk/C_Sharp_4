using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AverageMarkComparer : IComparer<Student>
    {
       // override
        //public  int Compare(Student x, Student y) => x.GetEverage.CompareTo(y.GetEverage);
        public int Compare(Student x, Student y)
        {
            return x.GetEverage.CompareTo(y.GetEverage);
            //throw new NotImplementedException();
        }
    }
}
