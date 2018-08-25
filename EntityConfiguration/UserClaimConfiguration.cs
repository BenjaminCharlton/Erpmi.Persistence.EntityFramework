using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class UserClaimConfiguration
    {
        public UserClaimConfiguration(EntityTypeBuilder<ApplicationUserClaim> entityBuilder)
        {
            entityBuilder.HasOne(u => u.User)
                .WithMany();
        }
    }
}
