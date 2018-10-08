using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        static public List<Order> orderList = new List<Order>();
        static private List<Order> foundOrderList = new List<Order>();

        static public void findOrderWithCustomerName()
        {
            foundOrderList.Clear();
            Console.Write("Input the customer Name you want to find：");
            string customerName = Console.ReadLine();
            foreach (Order anOrder in orderList)
            {
                if (anOrder.aDetail.cutomerName.Equals(customerName))
                {
                    foundOrderList.Add(anOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("404 NOT FOUND\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderWithGoodsName()
        {
            foundOrderList.Clear();
            Console.Write("Input the goods name you want to find：");
            string productName = Console.ReadLine();
            foreach (Order rinneOrder in orderList)
            {
                if (rinneOrder.aDetail.goodsName.Equals(goodsName))
                {
                    foundOrderList.Add(rinneOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("404 NOT FOUND\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderWithOrderNumber()
        {
            foundOrderList.Clear();
            Console.Write("Input the Number of the order you want to find：");
            string orderNum = Console.ReadLine();
            foreach (Order anOrder in orderList)
            {
                if (anOrder.aDetail.orderNum.Equals(orderNum))
                {
                    foundOrderList.Add(anOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("404 NOT FOUND\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static private void ShowOrder()
        {
            Console.WriteLine("The order you are finding：");
            foreach (Order anOrder in foundOrderList)
            {
                Console.WriteLine("Order Number：" + anOrder.aDetail.orderNum);
                Console.WriteLine("Customer Name：" + anOrder.aDetail.cutomerName);
                Console.WriteLine("Goods Name：" + anOrder.aDetail.goodsName + "\n");
            }
        }

        static public void AddOrder()
        {
            Order anOrder = new Order();
            try
            {
                anOrder.SetData();
                orderList.Add(anOrder);
                Console.WriteLine("Done!\n");
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Input error!(" + exception.Message + ")\n");
            }
        }

        static public void DeleteOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("Not found the order you want to delete.");
                }
                Console.Write("Select which order you want to delect：");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("The input number is over the max number.");
                    }
                    orderList.Remove(foundOrderList[num - 1]);
                    Console.WriteLine("Done!\n");
                }
                else if (condition == "")
                {
                    foreach (Order anOrder in foundOrderList)
                    {
                        orderList.Remove(anOrder);
                    }
                    Console.WriteLine("Done!\n");
                }
                else
                {
                    throw new OrderException("Input error!");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Input error!(" + exception.Message + ")\n");
            }

        }

        static public void ChangeOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("Not found.");
                }
                Console.Write("Select which order you want to change：");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("Input number is over the maxNumber!");
                    }
                    Console.WriteLine("Input the changed information：");
                    foundOrderList[num - 1].SetData();
                    Console.WriteLine("Done!\n");
                }
                else if (condition == "")
                {
                    Console.WriteLine("Done!\n");
                }
                else
                {
                    throw new OrderException("Input irlegally!");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Fail to change!(" + exception.Message + ")\n");
            }
        }
    }
}