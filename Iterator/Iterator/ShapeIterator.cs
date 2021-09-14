using System.Linq;

namespace IteratorExample
{
    public class ShapeIterator : Iterator<Shape>
    {
        private Shape[] shapes;
        public int position = 0;

        public ShapeIterator(Shape[] shape)
        {
            this.shapes  =  shape;
        }

        public bool HasNext()
        {
            return position < this.shapes.Length;
        }
        
        public Shape Next()
        {
            return this.shapes[position++];            
        }
        
        public void Remove()
        {
            shapes = shapes.Where((source, index) => index != shapes.Length-1).ToArray();
        }

    }
}