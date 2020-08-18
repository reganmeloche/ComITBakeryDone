using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComitBakery.Models;
using ComitBakery.DAL;

namespace ComitBakery.Controllers
{
    public class InventoryController : Controller
    {
        private IStoreInventoryItems _inventoryStorage;

        public InventoryController(IStoreInventoryItems inventoryStorage)
        {
            _inventoryStorage = inventoryStorage;
        }

        public IActionResult Index() {
            var result = _inventoryStorage.GetAll();
            return View(result);
        }

        public IActionResult Details(Guid id) {
            var item = _inventoryStorage.GetById(id);
            return View(item);
        }

        public IActionResult Create() {
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(InventoryItem newItem) {
            newItem.Id = Guid.NewGuid();
            newItem.Batches = new List<Batch>();
            _inventoryStorage.Create(newItem);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id) {
            ViewBag.IsEditing = true;
            var item = _inventoryStorage.GetById(id);
            return View("Upsert", item);
        }

        [HttpPost]
        public IActionResult Update(InventoryItem updatedItem) {
            _inventoryStorage.Update(updatedItem);
            return RedirectToAction("Details", "Inventory", new { id = updatedItem.Id});
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            _inventoryStorage.Delete(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
