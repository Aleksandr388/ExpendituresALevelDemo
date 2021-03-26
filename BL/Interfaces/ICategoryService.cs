using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICategoryService
    {
        CategoryModel Create(CategoryModel model);
        CategoryModel Update(CategoryModel model);
        IEnumerable<CategoryModel> GetAll();
        void Delete(CategoryModel model);
        CategoryModel GetById(int id);
    }
}
