using System;

namespace ComitBakery.Models
{
    public class TransactionItem
    {
        public Guid TransactionId {get;set;}
        public Guid InventoryItemId {get;set;}
        public Guid BatchId {get;set;}
        public int Quantity {get;set;}
    }
}
