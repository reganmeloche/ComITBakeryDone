using System;
using System.Collections.Generic;

namespace ComitBakery.Models
{
    public class Transaction
    {
        public Guid Id {get;set;}
        public List<TransactionItem> ItemsSold {get;set;}
        public DateTime TransactionDate {get;set;}
    }
}
