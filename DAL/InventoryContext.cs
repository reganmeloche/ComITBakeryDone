using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ComitBakery.Models;

namespace ComitBakery.DAL 
{
    public class InventoryContext : DbContext {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) {}

        public DbSet<InventoryItem> Items { get; set; }
    }
}