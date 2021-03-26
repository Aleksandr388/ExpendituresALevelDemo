using System;
using System.Collections.Generic;
using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Entites;
using DAL.Repositories;

namespace BL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }

        public CategoryModel Create(CategoryModel model)
        {
            var categoryModel = _mapper.Map<Category>(model);

            var createdCategory = _categoryRepository.Create(categoryModel);

            return _mapper.Map<CategoryModel>(createdCategory);
        }

        public void Delete(CategoryModel model)
        {
            var deleteModel = _mapper.Map<Category>(model);
            _categoryRepository.Delete(deleteModel);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            IEnumerable<Category> models = _categoryRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<CategoryModel>>(models);

            return mappedModels;
        }

        public CategoryModel GetById(int id)
        {
            var model = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryModel>(model);
        }

        public CategoryModel Update(CategoryModel model)
        {
            var categoruModel = _mapper.Map<Category>(model);

            var updatedCategory = _categoryRepository.Update(categoruModel);

            return _mapper.Map<CategoryModel>(updatedCategory);
        }
    }
}
