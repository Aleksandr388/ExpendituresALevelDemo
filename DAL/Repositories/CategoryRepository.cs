using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CategoryRepository : ExpenditureGenericRepository<Category, int>, ICategoryRepository
    {
        private readonly ExpenditureContext _ctx;

        public CategoryRepository(ExpenditureContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
