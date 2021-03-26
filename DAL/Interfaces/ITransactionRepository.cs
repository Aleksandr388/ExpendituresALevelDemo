using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;
using DAL.Interfaces;

namespace DAL.Interfaces
{
    public interface ITransactionRepository : IExpenditureGenericRepository<Transaction, int>
    {
    }
}
