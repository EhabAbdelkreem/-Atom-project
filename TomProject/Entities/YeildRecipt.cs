using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class YeildRecipt
    {

        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public float CaratPrice { get; set; }
        public float AcrePrice { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
