using System;
using System.Reflection.Metadata;

namespace OelApp
{
    public class Controller
    {
        private IView view;

        private Person user;
        private Session session;

        public Controller(IView view)
        {
            this.view = view;
        }

        public void StartSession()
        {
            view.print("Write your name:");
            AddPerson(view.read());

            view.print("Write your weight in kilograms your fat fuck:");
            user.Weight = int.Parse(view.read());

            view.print("Write your age:");
            user.Age = int.Parse(view.read());

            view.print("Write your gender, there are only two. M for male, F for female:");
            user.GenderCoef = view.read() == "M" ? 0.7 : 0.6;

            session = new Session {Person = user, StartTime = DateTime.Now};

            while (true)
            {
                view.print("What are you drinking? Type B for beer");
                if (view.read().Equals("B"))
                {
                    RegisterDrink(TypeOfDrink.beer);
                }
            }
        }

        public void AddPerson(string name)
        {
            user = new Person {Name = name};
            view.print($"{name} is now the user of this session!");
        }

        public void RegisterDrink(TypeOfDrink drink)
        {
            if (drink.Equals(TypeOfDrink.beer)) session.NumberOfUnits++;
            view.print($"{user.Name} just drank a {drink} and now his/her BAC is now {UnitConversionUtility.CalculateBac(session)}");
        }
    }
}