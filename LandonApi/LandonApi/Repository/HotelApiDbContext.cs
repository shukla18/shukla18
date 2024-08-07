using LandonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LandonApi.Repository
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
