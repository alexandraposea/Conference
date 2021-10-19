using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conference.Data
{
    public static class DependencyInjectionExtensions
    {
        public static void AddConferenceDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            
            var connectionString = configuration.GetConnectionString("Conference_Database");
            services.AddDbContextPool<ConferenceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
