using API.Extensions;
using API.Helpers;
using Core.Entities.Identity;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CalcularMora>();

            services.AddHttpClient
                ("BackEndDeveloper", client =>
            {
                //client.BaseAddress = new Uri("https://localhost:7050/");
                //client.BaseAddress = new Uri("https://sinfin-test-backend.octtopro.com/");
                //client.BaseAddress = new Uri("https://sinfin-test-backend.t4mapps.com/");
                client.BaseAddress = new Uri("https://sinfin-developer-backend.octtopro.com//");
                //client.BaseAddress = new Uri("https://sinfin-backend.octtopro.com/");
            });

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));                    

            services.AddApplicationServices();

            services.AddIdentityServices(_configuration);

            //services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddSwaggerDocumentation();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoticaAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
