using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Models;
using ExpendituresALevelDemo.Models.Category;
using ExpendituresALevelDemo.Models.Transaction;

namespace ExpendituresALevelDemo.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<TransactionModel, TransactionViewModel>().ReverseMap();
        }
    }
}