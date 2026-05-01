using GitHub_project.Models;
using GitHub_project.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Services
{
    public class ZooService
    {
        private List<Animal> animals = new List<Animal>();
        private readonly AnimalRepository _repository;
        public ZooService(AnimalRepository repository) {  _repository = repository; }

        public void AddLion(string name) 
        { 
            animals.Add(new Lion(name));
            _repository.AddAnimal(new Lion(name));
        }
        public void AddDog(string name) 
        { 
            animals.Add(new Dog(name));
            _repository.AddAnimal(new Dog(name));
        }
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
        public Animal CheckName(string name)
        {
            foreach (var animal in animals) { if (animal.Name.Equals(name,StringComparison.OrdinalIgnoreCase)) return animal; }
            return null;
        }

    }
}
