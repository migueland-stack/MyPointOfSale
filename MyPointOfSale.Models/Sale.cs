using System;
using System.Collections.Generic;

namespace MyPointOfSale.Models
{
    internal class Sale
    {
        private readonly List<LineOfSale> _lineOfSales;
        private readonly NCF _ncf;

        private readonly DateTime _ocurredAt;
        private readonly bool _isCompleted;

        private readonly decimal _total;

        public Sale(Shop shop)
        {
            _lineOfSales = new List<LineOfSale>();
            _ocurredAt = DateTime.Now;
            _isCompleted = false;
            _total = default;
        }

    }
}
