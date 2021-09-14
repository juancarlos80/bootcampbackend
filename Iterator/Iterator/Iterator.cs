using System;

namespace IteratorExample
{
    public interface Iterator<T>
    {
        public bool HasNext();
        public T Next();
        public void Remove();
        
    }
}