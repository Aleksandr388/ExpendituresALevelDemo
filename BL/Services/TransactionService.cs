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
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }


        public TransactionModel Create(TransactionModel model)
        {
            var transactioModel = _mapper.Map<Transaction>(model);
            var createTransacton = _transactionRepository.Create(transactioModel);

            return _mapper.Map<TransactionModel>(createTransacton);
        }

        public void Delete(TransactionModel model)
        {
            var deleteModel = _mapper.Map<Transaction>(model);
            _transactionRepository.Delete(deleteModel);
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            IEnumerable<Transaction> models = _transactionRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<TransactionModel>>(models);

            return mappedModels;
        }

        public TransactionModel GetById(int id)
        {
            Transaction models = _transactionRepository.GetById(id);

            var mappedModels = _mapper.Map<TransactionModel>(models);

            return mappedModels;
        }

        public TransactionModel Update(TransactionModel model)
        {
            var transactionMapper = _mapper.Map<Transaction>(model);

            var updatedTrasaction = _transactionRepository.Update(transactionMapper);

            return _mapper.Map<TransactionModel>(updatedTrasaction);
        }
    }
}
