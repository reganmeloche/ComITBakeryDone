using System;

namespace ComitBakery.Models
{
    public class Batch
    {
        public Guid Id {get;set;}
        public Guid InventoryItemId {get;set;}
        public int Quantity {get;set;}
        public int RemainingQuantity {get;set;}
        public bool IsArchived {get;set;}
        public DateTime ProductionDate {get;set;}
    }
}
