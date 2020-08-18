using System;
using System.Collections.Generic;
using System.Linq;
using ComitBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace ComitBakery.DAL
{
    public class EFInventoryStorage : IStoreInventoryItems {
        InventoryContext _context;

        public EFInventoryStorage(InventoryContext context) {
            _context = context;
        }

        public InventoryItem GetById(Guid id) {
            return _context.Items.Include(x => x.Batches).FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
        public List<InventoryItem> GetAll() {
            return _context.Items
                .Include(x => x.Batches)
                .Where(x => x.IsDeleted == false)
                .ToList();
        }


        public void Create(InventoryItem item) {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Update(InventoryItem updatedItem) {
            _context.Update(updatedItem);
            _context.SaveChanges();
        }

        public void Delete(Guid id) {
            var item = GetById(id);
            item.IsDeleted = true;
            _context.Update(item);
            _context.SaveChanges();
        }

        public void AddBatch(Batch batch) {
            var item = GetById(batch.InventoryItemId);
            item.Batches.Add(batch);
            _context.SaveChanges();
        }

        public void UpdateBatch(Batch updatedBatch) {
            var item = GetById(updatedBatch.InventoryItemId);
            var batch = item.Batches.FirstOrDefault(x => x.Id == updatedBatch.Id);
            if (updatedBatch.RemainingQuantity > batch.RemainingQuantity) {
                throw new Exception("Invalid update");
            }
            batch.RemainingQuantity = updatedBatch.RemainingQuantity;
            _context.SaveChanges(); 
        }

        public void DeleteBatch(Guid Id, Guid batchId) {
            var item = GetById(Id);
            var batch = item.Batches.FirstOrDefault(x => x.Id == batchId);
            batch.IsArchived = true;
            _context.SaveChanges();
        }
    }
}
 