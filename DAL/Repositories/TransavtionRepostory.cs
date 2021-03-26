using DAL.Entites;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TransavtionRepostory : ExpenditureGenericRepository<Transaction, int>, ITransactionRepository
    {
        private readonly ExpenditureContext _ctx;
        public TransavtionRepostory(ExpenditureContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
