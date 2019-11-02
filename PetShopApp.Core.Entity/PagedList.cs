using System.Collections.Generic;

namespace PetShopApp.Core.Entity
{
    public class PagedList<T>
    {
        public int PageIndex { get; set; }
        public int PageTotal { get; set; }
        public int ItemsPrPage { get; set; }
        public int ItemsTotal { get; set; }
        public ICollection<T> Data { get; set; }
    }
}
