using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SistemaInventario.Core.Repositories;
using SistemaInventario.Core.Services;
using SistemaInventario.Data;
using SistemaInventario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaInventario.Api
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
            
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<INumberSequenceService, NumberSequenceService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<ICustomerTypeService, CustomerTypeService>();
            services.AddTransient<IUnitOfMeasureService, UnitOfMeasureService>();
            //services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Inventario", Version = "v1" }); });
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
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

            //app.UseSwagger(); app.UseSwaggerUI(c => { c.RoutePrefix = ""; c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Inventario V1"); });

        }
    }
}
