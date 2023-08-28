using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocHomeAssignmentRestApi.Authentication;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace PocHomeAssignmentRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            //  Change Scoped to Singleton if you want a single instance throughout the application lifetime or Transient if you want a new instance every time it's requested.
            services.AddScoped<ICategoryRepository, CategorygerRepository>();

            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();


            services.AddDbContext<DbContextConnector>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("LoggerDbContext")));



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "ApiKeyAuthenticationScheme"; 
                options.DefaultChallengeScheme = "ApiKeyAuthenticationScheme"; 
            })
            .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthenticationScheme", options =>
            {
                options.ApiKey = "xd4f!dfsd@sdf"; 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
