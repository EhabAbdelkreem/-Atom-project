using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class Wallet
    {
        public int ID { get; set; }
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public virtual WalletItem WalletItem { get; set; }

    }
}
