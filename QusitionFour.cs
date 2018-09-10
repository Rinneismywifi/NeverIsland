using System;

namespace homework1
{
    class QustionFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the first number:");
            string FirstStr = Console.ReadLine();
            float NumberOne = float.Parse(FirstStr);
            Console.WriteLine("Please input the second number:");
            string SecondStr = Console.ReadLine();
            float NumberTwo = float.Parse(SecondStr);
            Console.WriteLine("The first number times the second number is:" + (NumberOne * NumberTwo));
        }
    }
}
