using Microsoft.EntityFrameworkCore;
using ReStore.BackEnd.Entities;

namespace ReStore.BackEnd.Data;

public class StoreContext: DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options){}
    public DbSet<Product> Products => Set<Product>();
}
