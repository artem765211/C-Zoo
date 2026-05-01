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
                    case 1: OptionAddLion(); break;
                    case 2: OptionAddDog(); break;
                    case 3: FeedAnimal(); break;
                    case 4:

                        ShowList();
                        break;
                    case 5: AnimalSound(); break;
                    case 6: RemoveAnimal(); break;
                    case 7: return;
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
            Console.WriteLine("6. Remove animal");
            Console.WriteLine("7. Exit");
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
            if (CheckIfEmpty()) return;
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
            if (CheckIfEmpty()) return;
            PrintAnimals();
            Logs.Info("Enter animal number to feed");
            string s_number = Console.ReadLine();
            if (!int.TryParse(s_number, out int number)) { Logs.Error("Invalid number");Pause(); return; }
            if (number < 1 || number > _service.Count) { Logs.Error("ERROR: going beyond the list boundaries"); return; }
            if (!_service.FeedAnimal(number - 1)) { Logs.Error("Lion couldn't feeded"); }
            else { Logs.Success("Lion feeded"); }
            Pause();
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
                Pause();
                return;
            }
            if (number < 1 || number > _service.Count) { Logs.Error("going beyond the list boundaries"); Pause(); return; }
            _service.AnimalSound(number - 1);
            Pause();
        }
        private void RemoveAnimal()
        {
            Console.Clear();
            if (CheckIfEmpty()) return;
            PrintAnimals();
            Console.WriteLine("Enter animal number:");
            string s_remove_number = Console.ReadLine();
            if (!int.TryParse(s_remove_number, out int remove_number))
            {
                Logs.Error("Invalid number!");
                Pause();
                return;
            }
            if (remove_number < 1 || remove_number > _service.Count) { Logs.Error("going beyond the list boundaries"); Pause(); return; }

            var animal = _service.GetAnimals();
            string temp_name = animal[remove_number - 1].Name;
            _service.RemoveAnimal(remove_number - 1);
            Logs.Success($"{temp_name} удалено из списка!");
            Pause();
        }
        private bool CheckIfEmpty()
        {
            if (_service.Count == 0)
            {
                Logs.Error("List is empty");
                Pause();
                return true;
            }
            return false;
        }
        private void Pause()
        {
            Console.WriteLine("Enter any key");
            Console.ReadKey();
        }
    }
}
