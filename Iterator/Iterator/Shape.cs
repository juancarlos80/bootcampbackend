using System;

namespace IteratorExample
{
    public class Shape
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public Shape(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString() {
            return String.Format(
                "Shape: {0} Name: {1}", 
                Id, 
                Name);
        }

    }
}