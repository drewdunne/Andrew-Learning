using System;

namespace TTO2
{
    public class Input
    {
        public Input()
        {
            
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}