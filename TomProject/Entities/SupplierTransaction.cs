﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomProject.Entities
{
    internal class SupplierTransaction
    {

        public int ID { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string TransactionType { get; set; }

        public string Notes { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
