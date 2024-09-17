
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rockfast.ApiDatabase.Data;

namespace Rockfast.ApiDatabase.Extensions
{
    public static class InitialiseDb
    {
        public static async Task InitialiseDbSeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

            await SeedUsersDataAsync(context);
        }

        private static async Task SeedUsersDataAsync(ApiDbContext context)
        {
            if (!context.Users.Any())
            {
                await context.Users.AddRangeAsync(InitialData.Users);

                await context.SaveChangesAsync();
            }
        }
    }
}
