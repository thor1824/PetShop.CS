using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class PagedList<T>
    {
        public int pageIndex { get; set; }
        public int pageTotal { get; set; }
        public int itemsPrPage { get; set; }
        public int itemsTotal { get; set; }
        public ICollection<T> data { get; set; }
    }
}
