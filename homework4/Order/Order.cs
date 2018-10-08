using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        public OrderDetails aDetail = new OrderDetails();

        public void DataSettings()
        {
            Console.WriteLine("Input the order information：");
            Console.Write("Order Number：");
            string orderNumber = Console.ReadLine();
            if (orderNumber != "")
            {
                foreach (char num in orderNumber)
                {
                    if (char.IsDigit(num) == false)
                    {
                        throw new OrderException("Input error!!");
                    }
                }
                aDetail.orderNum = orderNumber;
            }
            Console.Write("Customer Name：");
            string customerName = Console.ReadLine();
            if (customerName != "")
            {
                aDetail.cutomerName = customerName;
            }
            Console.Write("Goods Name：");
            string goodsName = Console.ReadLine();
            if (goodsName != "")
            {
                aDetail.goodsName = goodsName;
            }
        }
    }
}
