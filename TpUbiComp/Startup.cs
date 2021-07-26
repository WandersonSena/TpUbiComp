using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TpUbiComp
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
            services.AddControllersWithViews();
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.AddJavaScriptBundle("/js/bundles/templateGeeksBundle.js",
                    "lib/inputmask/dist/inputmask.min.js",
                    "lib/template-geeks/js/chart.js",
                    "lib/template-geeks/js/chat.js",
                    "lib/template-geeks/js/main.js",
                    "lib/template-geeks/js/pricing.js",
                    "lib/template-geeks/js/sidebarMenu.js",
                    "lib/template-geeks/js/tnsSlider.js");

                pipeline.AddCssBundle("/css/bundles/templateGeeksBundle.css",
                    "lib/template-geeks/css/theme.css");

                pipeline.MinifyJsFiles("/js/bundles/templateGeeksBundle.js");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseWebOptimizer();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
