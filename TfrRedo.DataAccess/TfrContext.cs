using System.Data.Entity;
using TFR.Data.Models.Journey;

namespace TfrRedo.DataAccess
{
    public class TfrContext : DbContext
    {
        public DbSet<Journey> Journey { get; set; }
    }
}