using API.Extensions;
using API.Helpers;
using Infrastructure.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CalcularMora>();

            services.AddHttpClient
            ("BackEndDeveloper", client =>
            {
                client.BaseAddress = new Uri("https://sinfin-test-backend.octtopro.com/");
                //client.BaseAddress = new Uri("https://sinfin-backend.octtopro.com/");
            });

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddApplicationServices();

            services.AddIdentityServices(Configuration);

            services.AddSwaggerDocumentation();
            services.AddCors(opt => { opt.AddPolicy("CorsPolicy", policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If the environment is not production, show the developer page
            if (!env.IsEnvironment("Prod")) app.UseDeveloperExceptionPage();

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