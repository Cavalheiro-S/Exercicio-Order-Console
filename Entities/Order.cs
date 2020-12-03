using System;
using System.Collections.Generic;
using System.Text;
using PedidoConsole.Enums;
using System.Globalization;

namespace PedidoConsole.Entities
{
    class Order
    {
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        public Client client { get; set; }
        public List<OrderItem> orderItem { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            this.moment = moment;
            this.status = status;
            this.client = client;
        }

        public void addItem(OrderItem item)
        {
            orderItem.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            orderItem.Remove(item);
        }

        public double Total()
        {
            double total = 0.0;

            foreach(OrderItem item in orderItem)
            {
                total += item.subTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(OrderItem item in orderItem)
            {
                sb.Append(""+item.product.name+", ");
                sb.Append($"${item.product.price.ToString("F2", CultureInfo.InvariantCulture)}");
                sb.Append(", Quantity: " + item.quantity);
                sb.Append($", Subtotal: ${item.subTotal().ToString("F2", CultureInfo.InvariantCulture)}\n");
            }

            sb.Append($"\nTotal price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}\n");
            return sb.ToString();
        }
    }
}
