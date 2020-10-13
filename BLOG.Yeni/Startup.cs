using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOG.Yeni.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BLOG.Yeni
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

                services.Configure<IISServerOptions>(options =>
                {
                    options.AutomaticAuthentication = false;
                });
            services.AddMvc()
             .AddSessionStateTempDataProvider();
            services.AddSession();
                services.Configure<DatabaseConnect>(
              Configuration.GetSection(nameof(DatabaseConnect)));

                services.AddSingleton<IDatabaseConnect>(sp =>
                    sp.GetRequiredService<IOptions<DatabaseConnect>>().Value);

                services.AddSingleton<ErrorService>();
                services.AddSingleton<CategoryService>();
                services.AddSingleton<UserService>();
            services.AddMvcCore(options => options.EnableEndpointRouting = false).AddRazorViewEngine();
                services.AddControllers();
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
                app.UseHttpsRedirection();
                app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=listeleverileri}");
                });
            }
        }

        internal class Settings
        {
            public string ConnectionString { get; internal set; }
            public string Database { get; internal set; }
        }
    }
