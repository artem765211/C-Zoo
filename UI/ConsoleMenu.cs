using GitHub_project.Design;
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
                if (!int.TryParse(s_choice, out int choice)) { Logs.Error("Invalid number"); continue; }
                switch (choice)
                {
                    case 1:  OptionAddLion(); break;
                    case 2: OptionAddDog(); break;
                    case 3: FeedAnimal(); break;
                    case 4:
                         
                        ShowList();
                        break;
                    case 5: AnimalSound(); break;
                    case 6: return;
                    default:
                        Logs.Error("This command does not exist");
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
            Console.WriteLine("5. Make animal sound");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=========================");
        }
        private void OptionAddLion()
        {
            Console.Clear();
            Logs.Info("Enter the Lion's name: ");
            string t_name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(t_name)) { Logs.Error("Name is empty"); return; }
            _service.AddLion(t_name);
            Logs.Success($"{t_name} added!");
            Pause();
        }
        private void OptionAddDog()
        {
            Console.Clear();
            Logs.Info("Enter the Dog's name: ");
            string t_name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(t_name)) { Logs.Error("Name is empty"); return; }
            _service.AddDog(t_name);
            Logs.Success($"{t_name} added!");
            Pause();
        }
        private void ShowList()
        {
            Console.Clear();
            if (_service.Count == 0) { Logs.Info("List is empty"); Pause(); return; }
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
            if (_service.Count == 0){ Logs.Info("List is empty"); return; }
            PrintAnimals();
            Logs.Info("Enter animal number to feed");
            string s_number = Console.ReadLine();
            if (!int.TryParse(s_number, out int number)) { Logs.Error("Invalid number"); return;  }
            if (number < 1 || number > _service.Count) { Logs.Error("ERROR: going beyond the list boundaries"); return; }
            if (!_service.FeedAnimal(number-1)) { Logs.Error("Lion couldn't feeded"); }
            else { Logs.Success("Lion feeded"); }
            Pause();
        }
        private void Pause()
        {
            Console.WriteLine("Enter any key");
            Console.ReadKey();
        }
        private void AnimalSound()
        { 
            Console.Clear();
            PrintAnimals();
            Logs.Info("Enter animal number: ");
            string s_number = Console.ReadLine();
            if (!int.TryParse(s_number, out int number))
            {
                Logs.Error("Invalid number!");
                return;
            }
            if(number < 1 || number > _service.Count) { Logs.Error("going beyond the list boundaries"); Pause(); return; }
            _service.AnimalSound(number-1);
            Pause();


        }
    }
}
