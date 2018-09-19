using System;
using System.Collections;

namespace QusitionNine
{
    class Answer
    {
        static void Main(string[] args)
        {
            ArrayList dataList = CreateArr();
            PrimeNum(dataList);
            OutPrimeNum(dataList);
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        static ArrayList CreateArr()
        {

            ArrayList dataList = new ArrayList();

            for (int i = 0; i < 99; i++)
            {
                dataList.Add(i + 2);
            }

            return dataList;

        }

        static void PrimeNum(ArrayList dataList)
        {

            for (int i = 0; i < dataList.Count;i++)
            {
                int dataNum = int.Parse(dataList[i].ToString());
                if ((dataNum % 2 == 0 || dataNum % 3 == 0 || dataNum % 5 == 0 || dataNum % 7 == 0)
                    && dataNum != 2 && dataNum != 3 && dataNum != 5 && dataNum != 7)
                {
                    dataList.Remove(dataList[i]);
                    i--;
                }
            }

        }

        static void OutPrimeNum(ArrayList dataList)
        {
            Console.WriteLine("2到100以内的素数有：");

            foreach (var dataSample in dataList)
            {
                Console.WriteLine(dataSample);
            }

        }
    }
}
