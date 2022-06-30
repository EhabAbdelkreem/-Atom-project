using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class WalletItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Wallet> Wallet { get; set; } = new HashSet<Wallet>();
    }
}
