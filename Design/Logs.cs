using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub_project.Design
{
    public static class Logs
    {
        public static void Error(string message)
        {
            Write(message, ConsoleColor.Red, "ERROR");
        }
        public static void Success(string message)
        {
            Write(message, ConsoleColor.Green, "SUCCESS");
        }
        public static void Info(string message)
        {
            Write(message, ConsoleColor.Cyan, "INFO");
        }
        private static void Write(string message, ConsoleColor color, string prefix )
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{prefix}] {message}");
            Console.ResetColor();
        }
    }
}
