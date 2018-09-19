using System;

namespace QusitionSeven
{
    class Answer
    {
        static void Main(string[] args)
        {
            int[] anArray = inData();
            Console.WriteLine("输入的数据最大值是：" + Max(anArray));
            Console.WriteLine("输入的数据最小值是：" + Min(anArray));
            Console.WriteLine("输入的数据最平均值是：" + Ave(anArray));
            Console.WriteLine("输入的数据的和是：" + Sum(anArray));
            Console.ReadKey();
        }

        static int[] inData()
        {
            int dataSize = 0;
            try
            {
                Console.WriteLine("输入数据个数：");
                dataSize = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误！\n");
                inData();
            }

            if (dataSize == 0)
            {
                System.Environment.Exit(0);
            }

            int[] anArray = new int[dataSize];

            Console.WriteLine("输入数据：");

            for (int i = 0; i < dataSize; i++)
            {
                try
                {
                    anArray[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入有误!\n");
                    i--;
                }
            }

            return anArray;

        }

        static int Max(int[] anArray)
        {
            int dataMax = anArray[0];

            foreach (int dataNum in anArray)
            {
                if (dataNum > dataMax)
                {
                    dataMax = dataNum;
                }
            }

            return dataMax;

        }

        static int Min(int[] anArray)
        {
            int dataMin = anArray[0];

            foreach (int dataNum in anArray)
            {
                if (dataNum < dataMin)
                {
                    dataMin = dataNum;
                }
            }

            return dataMin;

        }

        static double Ave(int[] anArray)
        {
            double dataSum = Sum(anArray);

            double dataAve = dataSum / anArray.Length;

            return dataAve;

        }

        static int Sum(int[] anArray)
        {
            int dataSum = 0;

            foreach (int dataNum in anArray)
            {
                dataSum += dataNum;
            }

            return dataSum;

        }

    }
}
