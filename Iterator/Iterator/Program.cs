using System;

namespace IteratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeStorage storage = new ShapeStorage(5);
            storage.AddShape("Polygon");
            storage.AddShape("Hexagon");
            storage.AddShape("Circle");
            storage.AddShape("Rectangle");
            storage.AddShape("Square");

            ShapeIterator iterator = new ShapeIterator(storage.GetShapes());
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            Console.WriteLine("Apply removing while iterating...");
            iterator = new ShapeIterator(storage.GetShapes());
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
                iterator.Remove();
            }

        }
    }
}
