using BL.Models;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<TransactionModel, Transaction>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}
