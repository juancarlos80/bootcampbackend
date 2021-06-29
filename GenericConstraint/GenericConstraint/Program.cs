using System;

namespace GenericConstraint
{
    public class Program
    {
        static void Main(string[] args)
        {            

            Person.Unique.Name = "Pepe";
            Console.WriteLine( Person.Unique.Name );            
        }
        
    }    

    public static class Unique 
    { 
        public static string Name { get; set; }
    }


    class UniqueInstance<T> where T : new()
    {     
        private static T _Unique = new();
     
        public static T Unique {
            get { 
                return _Unique;                
            }
            set {                
                _Unique = value;
            }
        }

    }

    class Person : UniqueInstance<Person>
    {
        public string Name;
    }

}
