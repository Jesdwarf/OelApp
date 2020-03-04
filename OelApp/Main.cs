namespace OelApp
{
   class Program
    {
        static void Main(string[] args) 
        {
            ConsoleView view = new ConsoleView();
            Controller controller = new Controller(view);
            controller.StartSession();
        }
    }
}