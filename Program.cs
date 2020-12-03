using System;
using PedidoConsole.Entities;
using PedidoConsole.Enums;

namespace PedidoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client´s Data
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date= Convert.ToDateTime(Console.ReadLine());
            Client client = new Client(name, email, date);

            //Order´s Data
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            string status = Console.ReadLine();
            Console.WriteLine("How many items to this order? ");
            int quan = Convert.ToInt32(Console.ReadLine());
            Order order = new Order(DateTime.Now, Enum.Parse<OrderStatus>(status.ToUpper()),client);
            for (int i = 0; i < quan; i++)
            {
                //Product´s Data
                Console.WriteLine($"Enter #{i+1} item data:");
                Console.Write("Product name: ");
                string prodName= Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice= Convert.ToDouble(Console.ReadLine());
                Console.Write("Quantity: ");
                int prodQuan = Convert.ToInt32(Console.ReadLine());
                Product product = new Product(prodName, prodPrice);
                OrderItem item = new OrderItem(prodQuan, prodPrice, product);
                order.addItem(item);
            }

            Console.WriteLine("\nORDER SUMMARY:");
            Console.WriteLine("Order moment: "+ order.moment);
            Console.WriteLine("Order status: " + order.status);
            Console.WriteLine("Client:"+ client.ToString());
            Console.WriteLine("Order items:");
            Console.WriteLine(order.ToString()); 

        }
    }
}
