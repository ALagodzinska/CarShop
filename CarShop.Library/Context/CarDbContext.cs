using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library.Context
{
    public class CarDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Recipient> Reciept { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3UCCBUV\SQLEXPRESS01; Database=CarShopDB; Trusted_Connection=True;");
    }
}
