using System;
using System.Collections.Generic;

namespace Library
{
    public class Renderer
    {
        public Renderer()
        {
            Console.CursorVisible = false;
        }
        
        public void DrawMenu(Menu.Menu menu)
        {
            Clear();
            
            for (int i = 0; i < menu.Count; i++)
            {
                KeyValuePair<string, string> menuElement = menu.GetElementByIndex(i);
                Console.WriteLine($"{menuElement.Key}. {menuElement.Value}");
            }
        }

        public void DrawMessage(string message)
        {
            Console.Write(message);
            Console.ReadKey();
        }

        public void DrawList(List<string> values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            
            Console.WriteLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string WaitUserInput(string beforeInputMessage)
        {
            Console.Write(beforeInputMessage);

            return Console.ReadLine();
        }
    }
}