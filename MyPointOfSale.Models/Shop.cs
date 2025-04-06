using System.Collections.Generic;

namespace MyPointOfSale.Models
{
    public class Shop
    {
        private List<NCF> _ncf;
        private List<Sale> _sales;
        private readonly Store _store;
        private readonly PointOfSale _pointOfSale;

        public Shop()
        {
            _ncf = new List<NCF>();
            _sales = new List<Sale>();
            _store = new Store();
            _pointOfSale = new PointOfSale(_store);
        }
    }
}
