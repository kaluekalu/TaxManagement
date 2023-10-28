using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Core.Implementation;
using TaskManagementAPI.Core.Services;
using TaskManagementAPI.Model.TaskDbContext;

namespace TaxManagementAPI.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("conn"));
            });


            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
