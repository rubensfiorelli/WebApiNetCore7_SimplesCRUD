using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Data.DatabaseContext;

namespace Store.CrossCutting.DependencyInjection
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            services.AddDbContext<StoreDbContext>(opts =>
            {
                string connectionSql = configuration.GetConnectionString("OakleySql")!;
                opts.UseSqlServer(connectionSql);

            });


            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            //services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            //services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            //services.AddScoped(typeof(IProductService), typeof(ProductService));

            return services;
        }
    }
}
