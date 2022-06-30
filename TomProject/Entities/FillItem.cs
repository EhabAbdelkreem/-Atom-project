using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class FillItem
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }


        public virtual ICollection<FillRecipet> FillRecipet { get; set; } = new HashSet<FillRecipet>();
        public virtual ICollection<ExportRecipet> ExportRecipet { get; set; } = new HashSet<ExportRecipet>();
        public virtual ICollection<harvestedRecipet> harvestedRecipet { get; set; } = new HashSet<harvestedRecipet>();

    }
}
