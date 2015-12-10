using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProduct = new List<Product>();
            string separator = "*";
            separator = separator.PadLeft(33, '*') + separator.PadRight(33, '*');

            listProduct.Add(new Powder(25, "Ариэль", "для светлых тканей", "ООО \"Проктер энд Гэмбл\"", 0));
            listProduct.Add(new Powder(50, "Миф", "для белых тканей", "ООО \"Чистый мир\"", 1));

            foreach (Product lpr in listProduct)
            {
                lpr.Show();
                Console.WriteLine(separator);
            }
        }
    }

    abstract class Product
    {
        protected string typeProduct;

        public Product(string typeProduct_)
        {
            typeProduct = typeProduct_;
        }
        public virtual void Show()
        {

        }
        
    }

    abstract class HomeChemicals : Product
    {
        protected string typeHomeChemicals;

        public HomeChemicals(string typeHomeChemicals_)
            : base("Бытовая химия")
        {
            typeHomeChemicals = typeHomeChemicals_;
        }

        public override void Show()
        {

        }
    }

    class Powder : HomeChemicals // порошки
    {
        private double weight;
        private string namePowder;
        private string use;
        private string producer;
        private byte typeWash; // 0 - ручная, 1 - автомат

        public Powder(double weight_, string namePowder_, string use_, string producer_, byte typeWash_) 
            : base("Порошок")
        {
            weight = weight_;
            namePowder = namePowder_;
            use = use_;
            producer = producer_;
            typeWash = typeWash_;
        }

        public override void Show()
        {
            StringBuilder str = new StringBuilder();

            if (typeWash == 1)
            {
                str.Append("Машинная стирка");
            }
            else
            {
                str.Append("Ручная стирка");
            }
            Console.WriteLine("Название: {0}, Вес: {1} кг., Применение: {2}, Производитель: {3}, Тип стирки: {4}", namePowder, weight, use, producer, str); 
        }
    }


    /*class Powder : HomeChemicals // порошки
    {

    }*/

    /*class FoodItems : Product
    {

    }*/



}
