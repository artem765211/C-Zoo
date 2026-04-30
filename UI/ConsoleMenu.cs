using GitHub_project.Models;
using GitHub_project.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.UI
{
    public class ConsoleMenu
    {
        private readonly ZooService _service;
        public ConsoleMenu(ZooService service)
        {
            _service = service;
        }

        public void Run() 
        { 
            while (true)
            {
                Console.Clear();
                ShowOptions();
                string s_choice = Console.ReadLine();
                if (!int.TryParse(s_choice, out int choice)) { Console.WriteLine("Invalid number"); continue; }
                switch (choice)
                {
                    case 1:  OptionAddLion(); break;
                    case 2: OptionAddDog(); break;
                    case 3: FeedAnimal(); break;
                    case 4:
                         
                        ShowList();
                        break;
                    case 5: return;
                    default:
                        Console.WriteLine("This command does not exist");
                        break;
                }
            }
        }
        private void ShowOptions()
        {
            Console.WriteLine("Choice option");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Add Lion");
            Console.WriteLine("2. Add Dog");
            Console.WriteLine("3. Feed the animal");
            Console.WriteLine("4. Show List the animals");
            Console.WriteLine("5. Exit");
            Console.WriteLine("=========================");
        }
        private void OptionAddLion()
        {
            Console.Clear();
            Console.Write("Enter the Lion's name: ");
            string t_name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(t_name)) { Console.WriteLine("ERROR: Name is empty"); return; }
            _service.AddLion(t_name);
            Console.WriteLine($"{t_name} added!");
            Pause();
        }
        private void OptionAddDog()
        {
            Console.Clear();
            Console.WriteLine("Enter the Dog's name: ");
            string t_name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(t_name)) { Console.WriteLine("ERROR: Name is empty"); return; }
            _service.AddDog(t_name);
            Console.WriteLine($"{t_name} added!");
            Pause();
        }
        private void ShowList()
        {
            Console.Clear();
            if (_service.Count == 0) { Console.WriteLine("List is empty"); Pause(); return; }
            PrintAnimals();
            Pause();
            
        }
        private void PrintAnimals()
        {
            int i = 1;
            foreach (var item in _service.GetAnimals())
            {
                Console.WriteLine($"{i}. | {item.Type()} | {item.Name} | Energy: {item.Energy}");
                i++;
            }
        }
        private void FeedAnimal()
        {
            if (_service.Count == 0){ Console.WriteLine("List is empty"); return; }
            PrintAnimals();
            Console.WriteLine("Enter animal number to feed");
            string s_number = Console.ReadLine();
            if (!int.TryParse(s_number, out int number)) { Console.WriteLine("Invalid number"); return;  }
            if (number < 1 || number > _service.Count) { Console.WriteLine("going beyond the list boundaries"); return; }
            if (!_service.FeedAnimal(number-1)) { Console.WriteLine("Lion couldn't feeded"); }
            else { Console.WriteLine("Lion feeded"); }
            Pause();
        }
        private void Pause()
        {
            Console.WriteLine("Enter any key");
            Console.ReadKey();
        }
    }
}
