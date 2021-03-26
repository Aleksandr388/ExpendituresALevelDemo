using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpendituresALevelDemo.Models.History
{
    public class HistoryViewModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}