using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Interfaces;
using BL.Models;
using ExpendituresALevelDemo.Models;
using ExpendituresALevelDemo.Models.Category;

namespace ExpendituresALevelDemo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {

            _mapper = mapper;

            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult MyCategories()
        {

            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAll());

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {

            var categoryModel = _mapper.Map<CategoryViewModel>(_categoryService.GetById(id));

            return View(categoryModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.UpdatedDate = DateTime.UtcNow;

            var categoryModel = _mapper.Map<CategoryModel>(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _categoryService.Create(categoryModel);

                return RedirectToAction("MyCategories");
            }
            catch
            {
                throw new Exception("Failed to create an item");
            }
        }

        public ActionResult Edit(int id)
        {
            var updatedModel = _mapper.Map<CategoryModel>(_categoryService.GetById(id));

            if (updatedModel != null)
            {
                return View(updatedModel);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model)
        {

            model.UpdatedDate = DateTime.UtcNow;

            var categoryModel = _mapper.Map<CategoryModel>(model);

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _categoryService.Update(categoryModel);

                return RedirectToAction("MyCategories");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(CategoryModel model)
        {
            var deleteModel = _mapper.Map<CategoryModel>(model);

            try
            {
                _categoryService.Delete(deleteModel);

                return RedirectToAction("MyCategories");
            }
            catch
            {
                throw new Exception("There is no item to delete");
            }
        }
    }
}