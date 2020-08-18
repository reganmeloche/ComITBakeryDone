using System;
using System.Collections.Generic;
using System.Linq;
using ComitBakery.Models;

namespace ComitBakery.DAL
{
    public interface IStoreInventoryItems {
        // Reads
        InventoryItem GetById(Guid id);
        List<InventoryItem> GetAll();

        // Updates
        void Create(InventoryItem item);
        void Update(InventoryItem updatedItem);
        void Delete(Guid id);
    }
}
