using System;

namespace TTO2
{
    class Output
    {
        public Output()
        {
            
        }

        public void Render(string output)
        {
            Console.WriteLine(output);
        }

        public void Render(string[] output)
        {
            for (int item = 0; item < output.Length; ++item)
            {
                Console.WriteLine(output[item]);
            }
        }
    }
}