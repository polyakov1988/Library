using System.Collections.Generic;

namespace Library.database
{
    public abstract class Database<T> where T : Model.Model
    {
        protected readonly List<T> Elements = new List<T>();
        private int _nextId = 100;
        
        public int Count => Elements.Count;

        public void Add(T value)
        {
            Elements.Add(value);
            _nextId++;
        }

        public int GetNextId()
        {
            return _nextId;
        }

        public T GetElementByIndex(int index)
        {
            return Elements[index];
        }
        
        public T GetElementById(int id)
        {
            foreach (var element in Elements)
            {
                if (element.Id == id)
                    return element;
            }
            
            return null;
        }

        public abstract bool HasElement(T model);
    }
}