using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class FillRecipet
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }
        public String Notes { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual FillItem FillItem { get; set; }



    }
}
