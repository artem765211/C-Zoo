using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project
{
    public class Lion : Animal
    {
        public Lion(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} growls");
        }
    }
}
