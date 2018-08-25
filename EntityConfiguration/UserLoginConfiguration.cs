using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class UserLoginConfiguration
    {
        public UserLoginConfiguration(EntityTypeBuilder<ApplicationUserLogin> entityBuilder)
        {
            entityBuilder.HasKey(nameof(ApplicationUserLogin.LoginProvider), nameof(ApplicationUserLogin.ProviderKey));
     
            entityBuilder.HasOne(u => u.User)
                .WithMany();
        }
    }
}
