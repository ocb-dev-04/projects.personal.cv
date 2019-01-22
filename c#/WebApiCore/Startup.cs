using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelCore.Data;
using ModelCore.Entities;
using WebApiCore.Services;

namespace WebApiCore
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Construct

        public Startup(IConfiguration configuration) 
            => Configuration = configuration;

        #endregion

        #region ConfigureServices

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppRandI();
            services.AddDBInfo(Configuration);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj) 
            => obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        #endregion

        #region Configure ( app/env )

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            AppContext appContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            
            if(!appContext.Categories.Any())
            {
                appContext.Categories.AddRangeAsync(new List<Categories>()
                {
                    new Categories() { Name = "Cars", Products = new List<Products> {
                            new Products() { Name="Toyota" },
                            new Products() { Name="Honda" },
                            new Products() { Name="Suzuki" }
                    } },
                    new Categories() { Name = "Jeep", Products = new List<Products> {
                            new Products() { Name="Jeep Grand Cherokee" },
                            new Products() { Name="Range Rover Sport" }
                    } },
                    new Categories() { Name = "Truck" }

                });

                appContext.SaveChangesAsync();
            }

        }

        #endregion
    }
}
