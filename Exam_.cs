using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Exam: IDateAndCopy
    {
        public string subject;
        public int mark;
        public DateTime data;
        public Exam()
        {
            subject = "Matem";
            mark = 0;
            data = new DateTime(2000, 01, 01);
        }
        public Exam(string sub, int mar, DateTime da)
        {
            subject = sub;
            mark = mar;
            data = da;
        }

        public override string ToString()
        {
            return this.subject + " " + this.mark + " " + this.data;
        }

        public virtual object DeepCopy()
        {
            Exam other = new Exam(this.subject, this.mark, this.data);
            return other;
        }

        public DateTime Date
        {
            get { return data; }
            set { data = value; }
        }
    }
}
