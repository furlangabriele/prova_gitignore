using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calcolo
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        public override bool Equals(object obj)
        {
            return (obj as Calcolo).Expression == Expression;
        }
    }
}
