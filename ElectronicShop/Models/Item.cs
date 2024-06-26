﻿namespace ElectronicShop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id:000}, {Name}, {Description}, Price: {Price:N} €, Qty: {Quantity}";
        }
    }
}
