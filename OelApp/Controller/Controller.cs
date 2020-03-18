using System;
using System.Reflection.Metadata;

namespace OelApp
{
    public class Controller
    {
        private IView view;

        private Person user;
        private Session session;

        public UnitConversionUtility UnitConversionUtility
        {
            get => default;
            set { }
        }

        public Controller(IView view)
        {
            this.view = view;
        }

        public void StartSession()
        {
            view.print("Write your name:");
            AddPerson(view.read());
            session = new Session{Person = user, StartTime = DateTime.Now};
            
            
            RegisterDrink(TypeOfDrink.beer);
        }

        public void AddPerson(string name)
        {
            user = new Person {Name = name};
            
            view.print($"{name} is now the user of this session!");
        }

        public void RegisterDrink(TypeOfDrink drink)
        {
            view.print($"{user.Name} just drank a {drink}");
        }

        public Session Session
        {
            get => default;
            set { }
        }
    }
}