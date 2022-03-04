using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CreditContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<CreditContext>>()))
            {
                // Look for any movies.
                if (context.Credits.Any() || context.Bids.Any())
                {
                    return; // DB has been seeded
                }

                context.Credits.Add(new Credit
                {
                    Head = "Ипотечный кредит", Period = 10, Sum = 1000000,
                    Procent = 15
                });
                context.Credits.Add(new Credit
                {
                    Head = "Образовательный кредит", Period = 7, Sum = 300000,
                    Procent = 10
                });
                context.Credits.Add(new Credit
                {
                    Head = "Потребительский кредит", Period = 5, Sum = 500000,
                    Procent = 19
                });
                context.SaveChanges();
            }
        }
    }
}