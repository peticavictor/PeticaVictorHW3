using System;

namespace Task9
{
    class Wonder
    {
        public String name { set; get; }

        public Wonder(String name)
        {
            this.name=name;
        }

        public override string ToString()
        {
            return "Here is " + name;
        }
    }
}
