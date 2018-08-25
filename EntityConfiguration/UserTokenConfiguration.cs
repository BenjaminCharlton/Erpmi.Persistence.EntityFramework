using Erpmi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erpmi.Persistence.EntityFramework.EntityConfiguration
{
    public class UserTokenConfiguration
    {
        public UserTokenConfiguration(EntityTypeBuilder<ApplicationUserToken> entityBuilder)
        {
            entityBuilder.HasKey(
                nameof(ApplicationUserToken.UserId), 
                nameof(ApplicationUserToken.LoginProvider), 
                nameof(ApplicationUserToken.Name));
     
            entityBuilder.HasOne(t => t.User)
                .WithMany();
        }
    }
}
