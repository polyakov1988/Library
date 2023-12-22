using System.Collections.Generic;
using System.Linq;

namespace Library.Menu
{
    public abstract class Menu
    {
        protected Dictionary<string, string> Elements;

        public int Count => Elements.Count;

        public KeyValuePair<string, string> GetElementByIndex(int index)
        {
            return Elements.ElementAt(index);
        }
    }
}