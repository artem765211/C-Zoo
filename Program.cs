using GitHub_project;

List<Animal> animals = new List<Animal>();
void ShowOptions()
{
    Console.WriteLine("Choice option");
    Console.WriteLine("=========================");
    Console.WriteLine("1. Add Lion");
    Console.WriteLine("2. Feed the animal");
    Console.WriteLine("3. Show List the animals");
    Console.WriteLine("4. Exit");
    Console.WriteLine("=========================");
}
int choice = 1;
while(true)
{
    ShowOptions();
    string s_inwhile_choice = Console.ReadLine();
    if (!int.TryParse(s_inwhile_choice, out int inwhile_choice)) { Console.WriteLine("Enter the number!"); return; }
    if (inwhile_choice < 1 || inwhile_choice > 4) { Console.WriteLine("This command does not exist"); return; }
    switch (inwhile_choice)
    {
        case 1:
            Console.Clear();
            Console.Write("Enter the Lion's name: ");
            string t_name = Console.ReadLine();
            animals.Add(new Lion(t_name));
            Console.WriteLine($"{t_name} added!");
            break;
        case 2:
            Console.Clear();
            if (animals.Count == 0)
            {
                Console.WriteLine("List empty");
                break;
            }
            Console.WriteLine("Enter number animal, which one you want to feed");
            int i = 1;
            foreach (var animal in animals) { Console.WriteLine($"{i}. {animal.Name} | Energy: {animal.Energy}");i++; }
            string temp_s_choice = Console.ReadLine();
            if (!int.TryParse(temp_s_choice, out int temp_choice)) { Console.WriteLine("Invalid number");  break; }
            if (temp_choice <1 || temp_choice > animals.Count) { Console.WriteLine("Invalid animal number"); break; }
            animals[temp_choice - 1].Feed();
            Console.WriteLine("Successfully feeded");
            break;
        case 3: Console.Clear(); 
            if (animals.Count == 0)
            {
                Console.WriteLine("List empty");
                break;
            }
            int ib = 1; 
            foreach (var animal in animals) 
            { Console.WriteLine($"{ib}. {animal.Name} | Energy: {animal.Energy}"); ib++; };
            break;
        case 4: return;

    }
}