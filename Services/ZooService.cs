using GitHub_project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Services
{
    public class ZooService
    {
        private List<Animal> animals = new List<Animal>();

        public void AddLion(string name) { animals.Add(new Lion(name)); }
        public void AddDog(string name) { animals.Add(new Dog(name)); }
        public IReadOnlyList<Animal> GetAnimals() { return animals; }
        public bool FeedAnimal(int index)
        {
            if (index < 0 || index >= animals.Count) return false;
            animals[index].Feed();
            return true;
        }
        public int Count => animals.Count;
        public string GetName(int index) => animals[index].Name;
        public void AnimalSound(int index)
        {
            animals[index].MakeSound();
        }
        public void RemoveAnimal(int index)
        {
            animals.RemoveAt(index);
        }

    }
}
