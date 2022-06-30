using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class Supplier
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

        public decimal account { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<SupplierTransaction> Transactions { get; set; } = new HashSet<SupplierTransaction>();

        public virtual ICollection<FillRecipet> FillRecipet { get; set; } = new HashSet<FillRecipet>();
        public virtual ICollection<RawRecipet> RawRecipet { get; set; } = new HashSet<RawRecipet>();
        public virtual ICollection<YeildRecipt> YeildRecipt { get; set; } = new HashSet<YeildRecipt>();
        public virtual ICollection<harvestedRecipet> harvestedRecipet { get; set; } = new HashSet<harvestedRecipet>();




    }
}
