using Event.ProductsContract;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Consumer;
using UserCourseInteraction.Database;
using UserCourseInteraction.Models;
using UserCourseInteraction.Repositories;

namespace UserCourseInteraction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ApplicationDbContext
                >(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserCourseInteraction", Version = "v1" });
            });
            services.AddTransient<IRepository<ShoppingCart>, Repository<ShoppingCart>>();
            services.AddTransient<IRepository<ProductDto>, Repository<ProductDto>>();
            services.AddTransient<IRepository<WishList>, Repository<WishList>>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMassTransit(config =>
            {
                config.AddConsumer<ProductConsumer>();
                config.AddConsumer<ProductPropertiesConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost:5672");

                    cfg.ReceiveEndpoint("ProductQueue", c =>
                    {
                        c.ConfigureConsumer<ProductConsumer>(ctx);
                    });
                    cfg.ReceiveEndpoint("gg", c =>
                    {
                        c.ConfigureConsumer<ProductPropertiesConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();
            services.AddScoped<ProductConsumer>();
            services.AddScoped<ProductPropertiesConsumer>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserCourseInteraction v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
