using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Models
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks!");
        }
        public override string Type() => "Dog";
    }
}
