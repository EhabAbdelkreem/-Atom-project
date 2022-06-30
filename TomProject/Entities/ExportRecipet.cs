using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class ExportRecipet
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public int FillQuantity { get; set; }

        public int NumberOfUnit { get; set; }
        public float UnitWeight { get; set; }
        public float TotalWeight { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual FillItem FillItem { get; set; }

    }
}
