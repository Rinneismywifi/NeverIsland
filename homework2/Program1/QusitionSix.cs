using System;
using System.Collections;

namespace QusitionSix
{
    class Answer
    {
        static void Main(string[] args)
        {
            PrimeFactor();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void PrimeFactor()
        {
            int inputNum = 1,primeFactor = 2;
            try
            {
                Console.WriteLine("输入一个整数：");
                inputNum = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误!\n");
                PrimeFactor();
            }

            Console.Write("该整数的素数因子为：");

            if (inputNum == 1)
            {
                Console.WriteLine(inputNum);
            }
            else
            {
                while (primeFactor <= inputNum)
                {
                    if (inputNum % primeFactor == 0)
                    {
                        Console.Write(primeFactor + " ");
                        inputNum = inputNum / primeFactor;
                    }
                    else
                    {
                        primeFactor++;
                    }
                }
                Console.WriteLine();
            }

        }
    }
}