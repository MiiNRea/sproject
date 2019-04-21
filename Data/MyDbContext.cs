using Microsoft.EntityFrameworkCore;
using sproject.Models;

namespace sproject.Data{
    public class MyDbContext :DbContext{

    public MyDbContext(DbContextOptions<MyDbContext> option):base(option)
        {
        }

        public DbSet<Inventory> Inventories {get; set;}
        public DbSet<ProductInfo> ProductInfos {get; set;}
        public DbSet<PurchaseOrder> PurchaseOrders {get; set;}
        public DbSet<SupplierInfo> SupplierInfos {get; set;}
        public DbSet<SupplierPerformance> SupplierPerformances {get; set;}
        //public DbSet<InventoryQty> InventoryQties {get; set;}
        public DbSet<InventoryIn> InventoryIns {get; set;}
        public DbSet<PurchaseOrderType> PurchaseOrderTypes {get; set;}
        public DbSet<SupplierType> SupplierTypes {get; set;}
        public DbSet<PActivity> PActivities {get; set;}
        public DbSet<sproject.Models.InventoryIn> InventoryIn { get; set; }
    }
}   