using System;
using System.Reflection.Metadata;

namespace OelApp
{
    public class Controller
    {
        private IView view;
        
        private Person user;

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
            
            
        }

        public void AddPerson(string name)
        {
            user = new Person {name = name}; 
            view.print(name + " is now the user of this session!");
        }


        public Session Session
        {
            get => default;
            set { }
        }
    }
}