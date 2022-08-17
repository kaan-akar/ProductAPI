using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductAPI.CQRS.Handlers.CommandHandlers;
using ProductAPI.CQRS.Handlers.QueryHandlers;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ProductAPI
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
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ProductDatabaseContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnection")));
            services.AddTransient<CreateProductCommandHandler>();
            services.AddTransient<DeleteProductCommandHandler>();
            services.AddTransient<GetAllProductQueryHandler>();
            services.AddTransient<GetByIdProductQueryHandler>();
            services.AddTransient<GetProductByFilterQueryHandler>();
            services.AddMediatR(typeof(ProductDatabaseContext));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
