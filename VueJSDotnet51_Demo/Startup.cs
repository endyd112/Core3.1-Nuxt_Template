using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using VueCliMiddleware;
using VueJSDotnet51_Demo.Helper;
using VueJSDotnet51_Demo.Structure;
using static VueJSDotnet51_Demo.Structure.SMD_Struct;
using static VueJSDotnet51_Demo.Structure.Struct;

namespace VueJSDotnet51_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            

            var hBASIC_CFG = SharedMem.GetMappedFileHandle("MEM_BASIC");

            var tmp = (BASIC_CFG)Marshal.PtrToStructure(hBASIC_CFG, typeof(BASIC_CFG));

        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ADD CORS 
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "ClientApp/";
                }
                else
                {
                    spa.Options.SourcePath = "ClientApp/"; 
                    spa.UseVueCli(npmScript: "start");
                }


                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "start");
                }

            });
        }
    }
}
