using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITransactionService
    {
        TransactionModel Create(TransactionModel model);
        TransactionModel Update(TransactionModel model);
        IEnumerable<TransactionModel> GetAll();
        void Delete(TransactionModel model);
        TransactionModel GetById(int id);
    }
}
