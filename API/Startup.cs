using JustTradeIt.Software.API.Middlewares;
using JustTradeIt.Software.API.Repositories.Contexts;
using JustTradeIt.Software.API.Repositories.Implementations;
using JustTradeIt.Software.API.Repositories.Interfaces;
using JustTradeIt.Software.API.Services.Implementations;
using JustTradeIt.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JustTradeIt.Software.API
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
            //controller
            services.AddControllers();
            //database context
            services.AddDbContext<JustTradeItDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("JustTradeItConnectionString"),
                    b => b.MigrationsAssembly("JustTradeIt.Software.API"));
            });
            //authentication
            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtTokenAuthentication(Configuration);
            
            var jwtConfig = Configuration.GetSection("JwtConfig");
            //Services
            services.AddTransient<ITokenService>((c) => new TokenService(
                jwtConfig.GetSection("secret").Value,
                jwtConfig.GetSection("ExpirationInMinutes").Value,
                jwtConfig.GetSection("issuer").Value,
                jwtConfig.GetSection("audience").Value));
            
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<ITradeService, TradeService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IQueueService, QueueService>();
            //Repositories
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ITradeRepository, TradeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JustTradeIt.Software.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JustTradeIt.Software.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
