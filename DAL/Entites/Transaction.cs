using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Transaction : ITEntity<int>
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime? ExpenditureDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
