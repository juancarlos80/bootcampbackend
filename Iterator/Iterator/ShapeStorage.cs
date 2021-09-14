using System;

namespace IteratorExample
{
    class ShapeStorage
    {
        private Shape[] shapes;
        private int index = 0;

        public ShapeStorage(int size)
        {
            shapes = new Shape[size];
        }
        public void AddShape(string shape)
        {
            if (index < shapes.Length)
            {
                shapes[index++] = new Shape(index, shape);
            }
        }

        public Shape[] GetShapes()
        {
            return shapes;
        }
    }
}