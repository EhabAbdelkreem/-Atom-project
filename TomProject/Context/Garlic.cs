using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomProject.Entities;

namespace TomProject.Context
{
    internal class Garlic :DbContext
    {
        public Garlic() :base("name=GarlicModel")
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual DbSet<ExportRecipet> ExportRecipets { get; set; }
        public virtual DbSet<FillItem> FillItems { get; set; }
        public virtual DbSet<FillRecipet> FillRecipets { get; set; }
        public virtual DbSet<harvestedRecipet> harvestedRecipets { get; set; }
        public virtual DbSet<RawRecipet> RawRecipets { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletItem> WalletItems { get; set; }
        public virtual DbSet<YeildRecipt> YeildRecipts { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
}
