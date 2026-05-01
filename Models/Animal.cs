using GitHub_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Models
{
    public abstract class Animal : IFeedable
    {

        public string Name { get; }
        public int Energy {get; set;} = 10;

        public Animal(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            Name = name;
        }

        public void Feed()
        {
            Energy = Math.Min(Energy + 10, 100);
        }

        public abstract void MakeSound();
        public abstract string Type();
    }
}
