using Basics.Persistence;
using Erpmi.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Erpmi.Persistence.EntityFramework
{
    public class ApplicationDbContextSeeder : IDatabaseSeeder
    {
        private IUnitOfWork _unitOfWork;
        private ILogger _logger;

        public ApplicationDbContextSeeder(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            //await _unitOfWork.Database.MigrateAsync().ConfigureAwait(false);

            //if (!await _unitOfWork.Users.AnyAsync())
            //{
                _logger.LogInformation("Generating inbuilt accounts");

                //const string adminRoleName = "administrator";
                //const string userRoleName = "user";

                //await EnsureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
                //await EnsureRoleAsync(userRoleName, "Default user", new string[] { });

                //await CreateUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "admin@ebenmonney.com", "+1 (123) 000-0000", new string[] { adminRoleName });
                //await CreateUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "user@ebenmonney.com", "+1 (123) 000-0001", new string[] { userRoleName });

                _logger.LogInformation("Inbuilt account generation completed");
            }
    }
}
