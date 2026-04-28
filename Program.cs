using GitHub_project;

Animal lion = new Lion("Leo");
Animal lion1 = new Lion("Feonardo");
Animal lion2 = new Lion("Kako");



List<Animal> animals = new List<Animal>();
animals.Add(lion);
animals.Add(lion1);
animals.Add(lion2);
int i = 1;
foreach (Animal animal in animals)
{
    Console.WriteLine(i+ ". " + animal.Name +" | Energy: "+ animal.Energy);
    i++;
}