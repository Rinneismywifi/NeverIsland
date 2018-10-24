using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace program1
{
    public class OrderService
    {
        static public List<Order> orderList = new List<Order>();
        static public List<Order> foundOrderList = new List<Order>();

        static public void findOrderByCustomerName()
        {
            foundOrderList.Clear();
            Console.Write("Input the customer's name you want to find：");
            string customerName = Console.ReadLine();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.cutomerName.Equals(customerName)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByCustomerName(string condition)
        {
            foundOrderList.Clear();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.cutomerName.Equals(condition)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByProductName()
        {
            foundOrderList.Clear();
            Console.Write("Input the production's name you want to find：");
            string productName = Console.ReadLine();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.productName.Equals(productName)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByProductName(string condition)
        {
            foundOrderList.Clear();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.productName.Equals(condition)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByOrderNum()
        {
            foundOrderList.Clear();
            Console.Write("Input the order you want to find：");
            string orderNum = Console.ReadLine();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.orderNum.Equals(orderNum)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByOrderNum(string condition)
        {
            foundOrderList.Clear();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.orderNum.Equals(condition)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByOrderCost()
        {
            foundOrderList.Clear();
            Console.Write("Input the cost of the order you want to find：");
            string orderCost = Console.ReadLine();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.orderCost.Equals(orderCost)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByOrderCost(string condition)
        {
            foundOrderList.Clear();
            var serchList = from anOrder in orderList
                            where anOrder.aDetail.orderCost.Equals(condition)
                            select anOrder;
            foundOrderList = serchList.ToList<Order>();
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("None.\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static private void ShowOrder()
        {
            Console.WriteLine("The results are：");
            foreach (Order anOrder in foundOrderList)
            {
                Console.WriteLine("Order：" + anOrder.aDetail.orderNum);
                Console.WriteLine("Customer Name：" + anOrder.aDetail.cutomerName);
                Console.WriteLine("Production Name：" + anOrder.aDetail.productName);
                Console.WriteLine("Order Cost：" + anOrder.aDetail.orderCost + "yuan\n");
            }
        }

        static public bool AddOrder()
        {
            Order anOrder = new Order();
            try
            {
                anOrder.SetData();
                orderList.Add(anOrder);
                Console.WriteLine("Added!\n");
                return true;
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Input error!For:" + exception.Message + "\n");
                return false;
            }
        }

        static public bool AddOrder(string num, string name, string product, string cost)
        {
            try
            {
                Order anOrder = new Order(num, name, product, cost);
                orderList.Add(anOrder);
                Console.WriteLine("Added!\n");
                return true;
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Input error!For:" + exception.Message + "\n");
                return false;
            }
        }

        static public bool DeleteOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("Cannot Find The Order.");
                }
                Console.Write("Select the orders you want to delete or Enter to delete all:：");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("The number is over the maxinum order number.");
                    }
                    orderList.Remove(foundOrderList[num - 1]);
                    Console.WriteLine("Deleted.\n");
                    return true;
                }
                else if (condition == "")
                {
                    foreach (Order anOrder in foundOrderList)
                    {
                        orderList.Remove(anOrder);
                    }
                    Console.WriteLine("Deleted.\n");
                    return true;
                }
                else
                {
                    throw new OrderException("Input irlegally or the number is over the maxinum order number.");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Input error.For:" + exception.Message + "\n");
                return false;
            }

        }

        static public bool ChangeOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("Cannot Find The Order.");
                }
                Console.Write("Select the orders you want to change or Enter to give up:");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("The number is over the maxinum order number.");
                    }
                    Console.WriteLine("Input the changed data or Enter to keep the data：");
                    foundOrderList[num - 1].SetData();
                    Console.WriteLine("Have Changed.\n");
                    return true;
                }
                else if (condition == "")
                {
                    Console.WriteLine("Have Changed.\n");
                    return true;
                }
                else
                {
                    throw new OrderException("Input irlegally.");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("Failed.For:" + exception.Message + "\n");
                return false;
            }
        }

        static public void Import(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            orderList = xmlSerializer.Deserialize(fileStream) as List<Order>;
            fileStream.Close();
        }

        static public void Export(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, obj);
            fileStream.Close();
        }

    }
}