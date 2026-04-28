using GitHub_project;
using GitHub_project.Models;
using GitHub_project.Services;
using GitHub_project.UI;

ZooService service = new ZooService();
ConsoleMenu consoleMenu = new ConsoleMenu(service);
consoleMenu.Run();
