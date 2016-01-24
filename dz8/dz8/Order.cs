using System;
using System.Collections.Generic;
using System.Text;

namespace dz8
{
    struct Product
    {
        public uint productId;
        public string productName;
        public double productPrice;

        public Product(uint productId_, string productName_, double productPrice_)
        {
            productId = productId_;
            productName = productName_;
            productPrice = productPrice_;
        }
        public void Show()
        {
            Console.WriteLine("Id Заказа: {0}, Название товара: {1}, Цена товара: {2}",
                productId, productName, productPrice);
        }
    }

    class Order
    {
        private string idOrder;
        private List<Product> listOfProduct;

        public List<Product> ListOfProduct
        {
            get { return listOfProduct; }
        }

        public Order(int countOrders)
        {
            listOfProduct = new List<Product>();
            idOrder = "ID" + countOrders;
        }

        public void AddOrder()
        {
            Console.WriteLine("Добавляем заказ номер " + idOrder);
            AddProduct();
            while (true)
            {
                if (GetData.GetChoiceYesNo("Добавить еще товар?"))
                {
                    AddProduct();
                }
                else
                {
                    break;
                }
            }
        }

        public void AddProduct()
        {
            uint productId = (uint)(listOfProduct.Count + 1);
            Console.WriteLine("Добавляем товар № {0} в заказ № {1}", productId, idOrder);
            Console.WriteLine("Введите название товара");
            string productName = Console.ReadLine();
            Console.WriteLine("Введите цену товара");
            double productPrice = GetData.GetDouble();
            listOfProduct.Add(new Product(productId, productName, productPrice));
        }

        public void ShowProducts()
        {
            foreach (Product listPr in listOfProduct)
            {
                listPr.Show();
            }

        }




    }
}
