using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Interfaces;
using PasswordManager.Application.Services;
using PasswordManager.DAL;

namespace PasswordManager.API
{
    public static class Startup
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            RegitserDAL(services);
            RegitserServices(services);
        }

        private static void RegitserDAL(IServiceCollection services)
        {
            services.AddDbContext<PasswordManagerDbContext>(options =>
                options.UseInMemoryDatabase("PasswordManagerInMemoryDB"));
        }

        private static void RegitserServices(IServiceCollection services)
        {
            services.AddScoped<IRecordSrvice, RecordSrvice>();
        }
    }
}
