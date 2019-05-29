using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class KeyValuePear
    {

        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Key2ValuePear
    {

        public int Value { get; set; }
        public string Text { get; set; }
        public object Options { get; set; }
    }

    public class KeyValuePearWithbool
    {

        public int Value { get; set; }
        public string Text { get; set; }
        public bool Options { get; set; }
    }
}
