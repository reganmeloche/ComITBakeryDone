using System;
using System.Collections.Generic;
using System.Linq;
using ComitBakery.Models;

namespace ComitBakery.DAL
{
    public interface IStoreBatches {        
        Batch GetBatch(Guid InventoryItemId, Guid BatchId);
        void AddBatch(Batch newBatch);
        void UpdateBatch(Batch updatedBatch);
        void DeleteBatch(Guid id, Guid batchId);
    }
}
