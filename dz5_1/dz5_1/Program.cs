using System;
using System.Collections.Generic;

namespace dz5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = "*";
            separator = separator.PadLeft(33, '*') + separator.PadRight(33, '*');
            List<Article> listArticle = new List<Article>();
            listArticle.Add(new Article(4, "Tide", 22));
            listArticle.Add(new Article(6, "Ariel", 25));
            listArticle.Add(new Article(7, "Mif", 20));
            foreach (Article art in listArticle)
            {
                art.Show();
            }
            Console.WriteLine(separator);
            List<Client> listClient = new List<Client>();
            listClient.Add(new Client(33, "Жуков Игорь", "Громова 60", "385-25-25", 2, 2400.2));
            listClient.Add(new Client(34, "Петров Сергкй", "Лынькова 25-1", "195-12-35", 25, 23650.22));
            listClient.Add(new Client(35, "Лосев Дмитрий", "Толстого 119-3", "954-05-36", 20, 25400.23));
            foreach (Client clnt in listClient)
            {
                clnt.Show();
            }
            Console.WriteLine(separator);
            List<RequestItem> listRequestItem = new List<RequestItem>();
            listRequestItem.Add(new RequestItem(4, 240));
            listRequestItem.Add(new RequestItem(4, 22));
            listRequestItem.Add(new RequestItem(7, 36));
            foreach (RequestItem ri in listRequestItem)
            {
                ri.Show();
            }
            Console.WriteLine(separator);
            List<Request> listRequest = new List<Request>();
            listRequest.Add(new Request(1, 33, "4 6", ref listRequestItem, ref listArticle));
            foreach (Request rq in listRequest)
            {
                rq.Show();
            }
            Console.WriteLine(separator);
        }
    }

    struct RequestItem
    {
        public uint productId;
        public uint productCount;

        public RequestItem(uint productId_, uint productCount_)
        {
            productId = productId_;
            productCount = productCount_;
        }
        public void Show()
        {
            Console.WriteLine("Код товара: {0}, Количество: {1}", productId, productCount);
        }
    }

    struct Request
    {
        public uint clientId;
        public uint orderId;
        public string orderProducts;
        public double orderSumma;

        public Request(uint clientId_, uint orderId_, string orderProducts_, ref List<RequestItem> listRequestItem, ref  List<Article> listArticle)
        {
            clientId = clientId_;
            orderId = orderId_;
            orderProducts = "";
            orderSumma = 0;
            List<uint> productCount = new List<uint>();
            string[] stArray = orderProducts_.Split(' ');
            uint key = 0;
            double price = 0;
            for (int i = 0, count = stArray.Length; i < count; ++i)
            {
                try
                {
                    key = uint.Parse(stArray[i]);
                    // ищем количество 
                    foreach (RequestItem ri in listRequestItem)
                    {
                        if (ri.productId == key)
                        {
                            productCount.Add(ri.productCount);
                        }
                    }
                    // ищем цену
                    foreach (Article ar in listArticle)
                    {
                        if (ar.productId == key)
                        {
                            price = ar.productPrice;
                            orderProducts += ar.productName + " ";
                            break;
                        }
                    }
                    foreach (int pCount in productCount)
                    {
                        orderSumma += pCount * price;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Недопустимый ввод. ");
                }
            }
        }
        public void Show()
        {
            Console.WriteLine("Код Заказа: {0} Код Клиента: {1}, Перечень товаров: {2}, Сумма заказов: {3}",
                orderId, clientId, orderProducts, orderSumma);
        }
    }

    struct Client
    {
        public uint clientId;
        public string clientFio;
        public string clientAdress;
        public string clientPhone;
        public uint orderCount;
        public double orderSumma;

        public Client(uint clientId_, string clientFio_, string clientAdress_, string clientPhone_, uint orderCount_, double orderSumma_)
        {
            clientId = clientId_;
            clientFio = clientFio_;
            clientAdress = clientAdress_;
            clientPhone = clientPhone_;
            orderCount = orderCount_;
            orderSumma = orderSumma_;
        }
        public void Show()
        {
            Console.WriteLine("Код Клиента: {0}, ФИО: {1}, Адрес: {2}, Телефон: {3}, Количество: {4}, Сумма заказов: {5}",
                clientId, clientFio, clientAdress, clientPhone, orderCount, orderSumma);
        }
    }

    struct Article
    {
        public uint productId;
        public string productName;
        public double productPrice;

        public Article(uint productId_, string productName_, double productPrice_)
        {
            productId = productId_;
            productName = productName_;
            productPrice = productPrice_;
        }

        public void Show()
        {
            Console.WriteLine("Код Товара: {0}, Название товара: {1}, Цена товара: {2}", productId, productName, productPrice);
        }
    }
}
