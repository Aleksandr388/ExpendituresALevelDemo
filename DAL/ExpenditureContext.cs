using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpenditureContext : DbContext
    {
        public ExpenditureContext() : base("Data Source=.;Initial Catalog = ExpenditureDataBaseDemo; Integrated Security = true")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
