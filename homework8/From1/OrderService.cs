using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.XPath;

namespace program1
{
    public class OrderService
    {
        static private String numTest = @"^(?<year>[0-9]{4})(?<month>[0-9]{2})(?<day>[0-9]{2})[0-9]{3}$";
        static private String phoneTest = @"^1[0-9]{10}$";

        static public List<Order> orders = new List<Order>();

        static public IEnumerable<Order> FindByNum(string condition)
        {
            return orders.Where(order => order.num.Equals(condition));
        }

        static public IEnumerable<Order> FindByName(string condition)
        {
            return orders.Where(order => order.name.Equals(condition));
        }

        static public IEnumerable<Order> FindByProduct(string condition)
        {
            return orders.Where(order => order.product.Equals(condition));
        }

        static public IEnumerable<Order> FindByCost(string condition)
        {
            return orders.Where(order => order.cost.Equals(condition));
        }

        static private void IsRight(string num, string name, string product, string cost, string phone)
        {
            Match phoneMatch = Regex.Match(phone, phoneTest);
            Match numMatch = Regex.Match(num, numTest);

            if (!phoneMatch.Success)
            {
                throw new Exception("Phone number is wrong.");
            }
            else if (!numMatch.Success)
            {
                throw new Exception("Wrong number.");
            }
            else if (!double.TryParse(cost, out double doubleNum))
            {
                throw new Exception("Cost is wrong");
            }
            else if (name == "")
            {
                throw new Exception("Customer is wrong");
            }
            else if (product == "")
            {
                throw new Exception("Production is wrong");
            }
            else
            {
                int year = int.Parse(numMatch.Result("${year}"));
                int month = int.Parse(numMatch.Result("${month}"));
                int day = int.Parse(numMatch.Result("${day}"));
                if (month > 12)
                {
                    throw new Exception("The month is wrong");
                }
                else if (month == 2)
                {
                    if (year % 4 == 0 && ((year % 100 != 0) || (year % 4 == 400)))
                    {
                        if (day > 29)
                        {
                            throw new Exception("Date is wrong");
                        }
                    }
                    else
                    {
                        if (day > 28)
                        {
                            throw new Exception("Date is wrong");
                        }
                    }
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    if (day > 30)
                    {
                        throw new Exception("Date is wrong");
                    }
                }
                else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    if (day > 31)
                    {
                        throw new Exception("Date is wrong");
                    }
                }
            }
            foreach (Order obj in orders)
            {
                if (obj.num.Equals(num))
                {
                    throw new Exception("Order is coverd");
                }
            }
        }

        static private void IsRight(Order obj)
        {
            Match phoneMatch = Regex.Match(obj.phone, phoneTest);
            Match numMatch = Regex.Match(obj.num, numTest);

            if (!phoneMatch.Success)
            {
                throw new Exception("Order：" + obj.num + "\nThe phone number is wrong");
            }
            else if (!numMatch.Success)
            {
                throw new Exception("Order：" + obj.num + "\nOrder style is wrong");
            }
            else if (!double.TryParse(obj.cost, out double doubleNum))
            {
                throw new Exception("Order：" + obj.num + "\nCost is wrong");
            }
            else if (obj.name == "")
            {
                throw new Exception("Order：" + obj.num + "\nCustomer name is wrong");
            }
            else if (obj.product == "")
            {
                throw new Exception("Order：" + obj.num + "\nName is wrong");
            }
            else
            {
                int year = int.Parse(numMatch.Result("${year}"));
                int month = int.Parse(numMatch.Result("${month}"));
                int day = int.Parse(numMatch.Result("${day}"));
                if (month > 12)
                {
                    throw new Exception("Order：" + obj.num + "\nMonth is wrong");
                }
                else if (month == 2)
                {
                    if (year % 4 == 0 && ((year % 100 != 0) || (year % 4 == 400)))
                    {
                        if (day > 29)
                        {
                            throw new Exception("Order：" + obj.num + "\nDate is wrong");
                        }
                    }
                    else
                    {
                        if (day > 28)
                        {
                            throw new Exception("Order：" + obj.num + "\nDate is wrong");
                        }
                    }
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    if (day > 30)
                    {
                        throw new Exception("Order：" + obj.num + "\nDate is wrong");
                    }
                }
                else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    if (day > 31)
                    {
                        throw new Exception("Order：" + obj.num + "\nDate is wrong");
                    }
                }
            }

            int count = 0;
            foreach (Order order in orders)
            {
                if (order.num.Equals(obj.num))
                {
                    count++;
                }
                if (count > 2)
                {
                    throw new Exception("Order：" + obj.num + "/nThe order is already had.");
                }
            }
        }

        static public void AddOrder(string num, string name, string product, string cost, string phone)
        {
            IsRight(num, name, product, cost, phone);
            orders.Add(new Order(num, name, product, cost, phone));
        }

        static public void DelOrder(Order obj)
        {
            orders.Remove(obj);
        }


        static public void ChangeOrder(string num, string name, string product, string cost, string phone, Order obj)
        {
            IsRight(num, name, product, cost, phone);
            obj.num = num;
            obj.name = name;
            obj.product = product;
            obj.cost = cost;
            obj.phone = phone;
        }

        static public void TestOrder()
        {
            foreach (Order obj in orders)
            {
                IsRight(obj);
            }
        }

        static public void Import(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            List<Order> addOrders = xmlSerializer.Deserialize(fileStream) as List<Order>;
            foreach (Order order in addOrders)
            {
                try
                {
                    IsRight(order.num, order.name, order.product, order.cost, order.phone);
                    orders.Add(order);
                }
                catch
                {

                }
            }
            fileStream.Close();
        }

        static public void Export(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, obj);
            fileStream.Close();
        }

        static public void ConvertToHTMLAndOpen(string xmlFile)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            XPathNavigator nav = xml.CreateNavigator();
            nav.MoveToRoot();
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(@"D:\pixiv\GITHUBCLONE\homework8\order.xlst");
            string filePath = xmlFile.Substring(0, xmlFile.LastIndexOf("\\"));
            FileStream outStream = File.OpenWrite(filePath + "\\order.html");
            XmlTextWriter writer = new XmlTextWriter(outStream, System.Text.Encoding.UTF8);
            xsl.Transform(nav, null, writer);
            outStream.Close();
            System.Diagnostics.Process.Start(filePath + "\\order.html");
        }
    }
}