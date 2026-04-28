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
                ShowOptions();
                string s_choice = Console.ReadLine();
                if (!int.TryParse(s_choice, out int choice)) { Console.WriteLine("Invalid number"); return; }
                switch (choice)
                {
                    case 1: OptionAddLion(); break;
                    case 2: FeedAnimal(); break;
                    case 3: ShowList(); break;
                    case 4: return;
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
            Console.WriteLine("2. Feed the animal");
            Console.WriteLine("3. Show List the animals");
            Console.WriteLine("4. Exit");
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
        }
        private void ShowList()
        {
            Console.Clear();
            int i = 1;
            if (_service.Count == 0) { Console.WriteLine("List is empty"); return; }
            foreach(var item in _service.GetAnimals())
            {
                Console.WriteLine($"{i}. {item.Name} | Energy: {item.Energy}");
                i++;
            }
        }
        private void FeedAnimal()
        {
            if (_service.Count == 0){ Console.WriteLine("List is empty"); return; }
            ShowList();
            Console.WriteLine("Enter Lion, which want to feed");
            string s_number = Console.ReadLine();
            if (!int.TryParse(s_number, out int number)) { Console.WriteLine("Invalid number"); return;  }
            if (number < 1 || number > _service.Count) { Console.WriteLine("going beyond the list boundaries"); return; }
            if (!_service.FeedAnimal(number-1)) { Console.WriteLine("Lion couldn't feeded"); }
            else { Console.WriteLine("Lion feeded"); }
        }
    }
}
