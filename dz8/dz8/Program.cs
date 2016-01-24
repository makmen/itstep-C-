using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace dz8
{
    class Program
    {
        public static string pathXmlFile = "..//..//..//Orders.xml";
        public static string pathXSLFile = "..//..//..//Orders.xsl";
        public static string pathHTMLFile = "..//..//..//Orders.html";

        static void Main(string[] args)
        {
            Console.WriteLine("Сохраняем товары");
            Console.WriteLine("1. Добавить заказ"); // добавить заказ
            Console.WriteLine("2. Сохранить заказ в xml");
            Console.WriteLine("3. Прочитать xml файл");
            Console.WriteLine("4. Сгенирировать HTML из xml файл");
            Console.WriteLine("5. Выход");
            int menu;
            bool exit = false;
            List<Order> listOfOrders = new List<Order>();
            while (true)
            {
                menu = GetData.GetInt();
                if (menu < 1 || menu > 5)
                {
                    Console.WriteLine("Введите цифру от 1 - 5");
                }
                else
                {
                    switch (menu)
                    {
                        case 1:
                            Order newOrder = new Order(listOfOrders.Count + 1);
                            newOrder.AddOrder();
                            listOfOrders.Add(newOrder);
                            break;
                        case 2:
                            if (listOfOrders.Count == 0)
                            {
                                Console.WriteLine("Нет заказов. Добавьте заказы для записи");
                            }
                            else
                            {
                                if (OrdersWriter(listOfOrders))
                                {
                                    Console.WriteLine("Файл записан успешно в {0}", Path.GetFullPath(pathXmlFile));
                                }
                                else
                                {
                                    Console.WriteLine("Были ошибки при копировании");
                                }
                            }
                            break;
                        case 3:
                            if (OrdersReader(listOfOrders))
                            {
                                Console.WriteLine("Файл был прочитан успешно");
                            }
                            else
                            {
                                Console.WriteLine("Были ошибки при чтении файла {0}", Path.GetFullPath(pathXmlFile));
                            }
                            break;
                        case 4:
                            try
                            {
                                XslCompiledTransform xslt = new XslCompiledTransform();
                                xslt.Load(pathXSLFile);
                                xslt.Transform(pathXmlFile, pathHTMLFile);
                                Console.WriteLine("Файл HTML сгенирирован {0}", Path.GetFullPath(pathHTMLFile));
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("{0}", ex.Message);
                            }
                            break;
                        default:
                            exit = true;
                            break;
                    }
                }
                if (exit)
                {
                    break;
                }
            }
        }

        static public bool InArray(string[] array, string x)
        {
            for (int i = 0, count = array.Length; i < count; ++i)
            {
                if (array[i] == x)
                {
                    return true;
                }
            }

            return false;
        }

        static bool OrdersReader(List<Order> listOfOrders)
        {
            bool done = false;
            XmlTextReader reader = null;
            try
            {
                string[] needEtem = { "Orders", "Order", "Product", "productName", "productPrice" };
                reader = new XmlTextReader(pathXmlFile);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (InArray(needEtem, reader.Name) || reader.NodeType == XmlNodeType.Text)
                    {
                        Console.WriteLine("Type={0}\t\tName={1}\t\tValue={2}", reader.NodeType, reader.Name, reader.Value);
                        if (reader.AttributeCount > 0)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                Console.WriteLine("Type={0}\tName={1}\tValue={2}",
                                    reader.NodeType, reader.Name, reader.Value);
                            }
                        }
                    }
                }
                done = true;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return done;
        }


        static bool OrdersWriter(List<Order> listOfOrders)
        {
            bool done = false;
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(pathXmlFile, System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Orders");
                for (int i = 0, count = listOfOrders.Count; i < count; ++i)
                {
                    writer.WriteStartElement("Order");
                    writer.WriteAttributeString("id", "orderID" + (i + 1));
                      for (int j = 0, coun = listOfOrders[i].ListOfProduct.Count; j < coun; ++j)
                    {
                        writer.WriteStartElement("Product");
                        writer.WriteAttributeString("productId", "Product_" + listOfOrders[i].ListOfProduct[j].productId);
                        writer.WriteElementString("productName", listOfOrders[i].ListOfProduct[j].productName);
                        writer.WriteElementString("productPrice", "" + listOfOrders[i].ListOfProduct[j].productPrice);
                        writer.WriteEndElement(); // Product
                    }
                    writer.WriteEndElement(); // Order
                }
                writer.WriteEndElement(); // Orders
                done = true;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return done;
        }

    }
}
