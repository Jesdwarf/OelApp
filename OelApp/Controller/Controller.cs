using System;
using System.Collections.Generic;
using System.Net;

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
            user.Weight = double.Parse(view.read());

            // view.print("Write your age:");
            // user.Age = int.Parse(view.read());

            view.print("Write your gender, there are only two. M for male, F for female:");
            user.Gender = view.read().ToLower();

            session = new Session {Person = user, StartTime = DateTime.Now};

            while (true)
            {
                view.print("What are you drinking?");

                foreach (Drink drink in LoadDrinks())
                {
                    view.print(drink.Name);
                }
                view.print("");

                string input = view.read().ToLower();
                
                foreach (Drink drink in LoadDrinks())
                {
                    if (input.Equals(drink.Name.ToLower()))
                    {
                        RegisterDrink(drink);
                    }
                }
                
            }
        }

        public void AddPerson(string name)
        {
            user = new Person {Name = name};
            view.print($"{name} is now the user of this session!");
        }

        public void RegisterDrink(Drink drink)
        {
            session.NumberOfUnits += (int) drink.Units;
            view.print(
                $"{user.Name} just drank a {drink.Name} and now his/her BAC is now {UnitConversionUtility.CalculateBac(session)}");
        }

        public List<Drink> LoadDrinks()
        {
            return JsonDAL.ReadFromJsonFile<List<Drink>>();
        }
    }
}