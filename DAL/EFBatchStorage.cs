using System;
using System.Collections.Generic;
using System.Linq;
using ComitBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace ComitBakery.DAL
{
    public class EFBatchStorage : IStoreBatches {
        InventoryContext _context;
        IStoreInventoryItems _itemStorage;

        public EFBatchStorage(InventoryContext context, IStoreInventoryItems itemStorage) {
            _context = context;
            _itemStorage = itemStorage;
        }

        public Batch GetBatch(Guid inventoryItemId, Guid batchId) {
            var allItems = _itemStorage.GetAll();
            var item = allItems.FirstOrDefault(x => x.Id == inventoryItemId);
            var batch = item.Batches.FirstOrDefault(x => x.Id == batchId);
            return batch;
        }

        public void AddBatch(Batch batch) {
            var item = _itemStorage.GetById(batch.InventoryItemId);
            item.Batches.Add(batch);
            _context.SaveChanges();
        }

        public void UpdateBatch(Batch updatedBatch) {
            var item = _itemStorage.GetById(updatedBatch.InventoryItemId);
            var batch = item.Batches.FirstOrDefault(x => x.Id == updatedBatch.Id);

            if (updatedBatch.RemainingQuantity > batch.RemainingQuantity) {
                throw new Exception("Invalid update");
            }

            batch.RemainingQuantity = updatedBatch.RemainingQuantity;
            _context.SaveChanges(); 
        }

        public void DeleteBatch(Guid Id, Guid batchId) {
            var item = _itemStorage.GetById(Id);
            var batch = item.Batches.FirstOrDefault(x => x.Id == batchId);
            batch.IsArchived = true;
            _context.SaveChanges();
        }
    }
}
 