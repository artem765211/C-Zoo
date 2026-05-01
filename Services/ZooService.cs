using GitHub_project.Models;
using GitHub_project.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Services
{
    public class ZooService
    {
        
        private readonly AnimalRepository _repository;
        private List<Animal> animals = new List<Animal>();
        public ZooService(AnimalRepository repository) 
        { 
            _repository = repository;
            animals = _repository.GetAllAnimals();
        }

        public void AddLion(string name) 
        {
            Lion lionAnimal = new Lion(name);
            _repository.AddAnimal(lionAnimal);
            animals.Add(lionAnimal);
        }
        public void AddDog(string name) 
        {
            Dog dogAnimal = new Dog(name);
            _repository.AddAnimal(dogAnimal);
            animals.Add(dogAnimal);
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
        public Animal RemoveAnimal(int index)
        {
            var animal = animals.FirstOrDefault(a => a.id == index);
            _repository.RemoveAnimal(index);
            animals.Remove(animal);
            return animal;
        }
        public Animal CheckName(string name)
        {
            foreach (var animal in animals) { if (animal.Name.Equals(name,StringComparison.OrdinalIgnoreCase)) return animal; }
            return null;
        }


    }
}
