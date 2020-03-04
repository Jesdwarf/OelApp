using System;

namespace OelApp
{
    public class ConsoleView : IView
    {
        public void print(string message)
        {
            Console.WriteLine(message);
        }

        public string read()
        {
            return  Console.ReadLine();
        }
    }
}