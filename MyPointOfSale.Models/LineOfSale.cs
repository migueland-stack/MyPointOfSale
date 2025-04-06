using System;

namespace MyPointOfSale.Models
{
    internal class LineOfSale
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total => Product.Price * Quantity;

        public void AddQuantity(int quantity)
        {
            if (!(quantity >= 0))
            {
                throw new ArgumentException("La cantidad no puede ser cero o negativa");
            }

            Quantity += quantity;
        }
    }
}
