using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SB_Onboarding_1.Models;

namespace SB_Onboarding_1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<SB_Onboarding_1.Models.StoreModel> Tank { get; set; } = default!;
}
