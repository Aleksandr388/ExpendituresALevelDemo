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
using ExpendituresALevelDemo.Models.Transaction;

namespace ExpendituresALevelDemo.Controllers
{
    public class TransactionWithContextController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public TransactionWithContextController(ITransactionService transactionService, IMapper mapper, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        // GET: TransactionWithContext
        public ActionResult Index()
        {
            var transactions = _mapper.Map<IEnumerable<TransactionViewModel>>(_transactionService.GetAll());

            return View(transactions);
        }


        // GET: TransactionWithContext/Details/5
        public ActionResult Details(int id)
        {
            var transactionModel = _mapper.Map<TransactionViewModel>(_transactionService.GetById(id));

            return View(transactionModel);
        }

        // GET: TransactionWithContext/Create
        public ActionResult Create()
        {
            var model = new TransactionViewModel();
            model.CaetgoriesList = SelectCategories();
            return View(model);
        }

        // POST: TransactionWithContext/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel transactionModel)
        {
            transactionModel.CreatedDate = DateTime.UtcNow;
            transactionModel.UpdatedDate = DateTime.UtcNow;


            var model = _mapper.Map<TransactionModel>(transactionModel);
            if (ModelState.IsValid)
            {
                _transactionService.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: TransactionWithContext/Edit/5
        public ActionResult Edit(int id)
        {
            var updatedModel = _mapper.Map<TransactionViewModel>(_transactionService.GetById(id));
            updatedModel.CaetgoriesList = SelectCategories();

            if (updatedModel != null)
            {
                return View(updatedModel);
            }

            return HttpNotFound();
        }

        // POST: TransactionWithContext/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionViewModel model)
        {
            model.UpdatedDate = DateTime.UtcNow;


            var updatedModel = _mapper.Map<TransactionModel>(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                _transactionService.Update(updatedModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: TransactionWithContext/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(TransactionViewModel model)
        {
            var deleteModel = _mapper.Map<TransactionModel>(model);

            try
            {
                _transactionService.Delete(deleteModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region DropDownList
        public IEnumerable<SelectListItem> SelectCategories()
        {
            var model = new TransactionViewModel();

            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAll());


            model.CaetgoriesList = GetSelectListItems(categories);



            return model.CaetgoriesList;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<CategoryViewModel> categories)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Title

                });
            }
            return selectList;
        }
        #endregion
    }
}
