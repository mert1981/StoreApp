using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories;
using StoreApp.Models;
using Services.Contracts;
using Services;
using Entities.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            { options.UseSqlite(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("StoreApp")); });
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); //önbellek sağlıyor. sunucu tarafında bilgileri tutuyor sunucu durunca sessionu unutuyoruz
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10); //10 dakika bu bilgileri tut sonra taze bir istek yoksa oturumu düşür
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }

        public static void ConfigureRepositoryRegistirion(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ConfigureServiceRegistirion(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderManager>();
        }

        public static void ConfigureRouting(this IServiceCollection services )
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true; //url küçük harf olarak döner
                options.AppendTrailingSlash = false; //url sonuna / eklenmesini sağlar.Default olarak false geliyor
            });
        }
    }
}
