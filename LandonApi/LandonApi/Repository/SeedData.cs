namespace LandonApi.Repository
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            await AddTestData(serviceProvider.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddTestData(HotelApiDbContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }

            context.Rooms.Add(new Models.RoomEntity
            {
                Id = new Guid("415d60a7-65c9-4890-891c-4cc720234f1f"),
                Name = "Suite",
                Rate = 100
            });

            context.Rooms.Add(new Models.RoomEntity
            {
                Id = new Guid("4b185b75-c3d9-40bf-abbb-ebd72803576c"),
                Name = "Deluxe Room",
                Rate = 50
            });

            await context.SaveChangesAsync();

        }
}
