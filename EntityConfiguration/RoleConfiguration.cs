using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasKey(r => r.Id);

            entityBuilder.HasMany(r => r.Claims)
                .WithOne();

            entityBuilder.HasMany(r => r.Users)
                .WithOne();
        }
    }
}
