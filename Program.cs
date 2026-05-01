using GitHub_project;
using GitHub_project.Data;
using GitHub_project.Models;
using GitHub_project.Services;
using GitHub_project.UI;

AnimalRepository repository = new AnimalRepository();
repository.Initialize();
ZooService service = new ZooService(repository);
ConsoleMenu consoleMenu = new ConsoleMenu(service);
consoleMenu.Run();
