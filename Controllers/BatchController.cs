using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComitBakery.Models;
using ComitBakery.DAL;

namespace ComitBakery.Controllers
{
    public class BatchController : Controller
    {
        private readonly ILogger<BatchController> _logger;
        private IStoreBatches _batchStorage;

        public BatchController(ILogger<BatchController> logger, IStoreBatches batchStorage)
        {
            _logger = logger;
            _batchStorage = batchStorage;
        }

        public IActionResult Create(Guid inventoryItemId)
        {
            var batch = new Batch();
            batch.InventoryItemId = inventoryItemId;
            return View(batch);
        }

        [HttpPost]
        public IActionResult Create(Batch newBatch)
        {
            newBatch.RemainingQuantity = newBatch.Quantity;
            _batchStorage.AddBatch(newBatch);
            return RedirectToAction("Details", "Inventory", new { id = newBatch.InventoryItemId});
        }

        public IActionResult Update(Guid inventoryItemId, Guid batchId)
        {
            var batch = _batchStorage.GetBatch(inventoryItemId, batchId);
            return View(batch);
        }

        [HttpPost]
        public IActionResult Update(Batch updatedBatch)
        {
            _batchStorage.UpdateBatch(updatedBatch);
            return RedirectToAction("Details", "Inventory", new { id = updatedBatch.InventoryItemId});
        }

        [HttpPost]
        public IActionResult Delete(Guid inventoryItemId, Guid Id) {
            _batchStorage.DeleteBatch(inventoryItemId, Id);
            return RedirectToAction("Details", "Inventory", new { id = inventoryItemId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
