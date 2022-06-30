using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }


        public int Phone { get; set; }

        public string Address { get; set; }
        
        public decimal account { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<CustomerTransaction> Transactions { get; set; } = new HashSet<CustomerTransaction>();
        public virtual ICollection<ExportRecipet> ExportRecipet { get; set; } = new HashSet<ExportRecipet>();



    }
}
