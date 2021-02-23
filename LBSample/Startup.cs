using LBSample.Configuration;
using LBSample.DependencyInjection;
using LBSample.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using LBSample.Entity.Mappings;
using Microsoft.OpenApi.Models;

namespace LBSample
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

            ConnectionStringsConfiguration conn = Configuration.GetSection(ConnectionStringsConfiguration.ConnectionStrings).Get<ConnectionStringsConfiguration>();
            services.AddEntityFrameworkSqlServer().AddDbContext<SampleDBContext>(options => options.UseSqlServer(conn.DefaultConnection));

            services.Configure<ConnectionStringsConfiguration>(Configuration.GetSection("ConnectionStrings"));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            services.AddSingleton(config.CreateMapper());

            services.AddRepositoryConfig()
                    .AddDomainConfig()
                    .AddProviderConfig();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "LB Sample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "LB Sample v1");
            });

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
