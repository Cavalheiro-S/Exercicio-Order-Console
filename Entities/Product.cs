﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PedidoConsole.Entities
{
    class Product
    {
        public string name { get; set; }
        public double price { get; set; }

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
