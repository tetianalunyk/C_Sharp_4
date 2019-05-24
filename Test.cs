using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Test
    { 
        public string _subject{ get; set;}
        public bool _zarah { get; set; }
        public Test(string sub, bool zdav)
        {
            _subject = sub;
            _zarah = zdav;
        }
        public Test()
        {
            _subject = "NoSubject";
            _zarah = false;
        }
        public override string ToString()
        {
            return $"Subject: {_subject} Credit: {_zarah}";
        }

    }
}
