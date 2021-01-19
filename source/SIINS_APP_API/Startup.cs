using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SIINS_APP_API.Models;

namespace SIINS_APP_API
{
    public class Startup
    {
        private readonly string ServerCon = "Data Source=siins.site;Initial Catalog=SIINS;User ID=server;Password=tr2042255";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DB Settings
            services.AddDbContext<HomeworkDBContext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<NoteCatDBContext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<NoteClassDBContext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<UserCategoriesDBcontext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<CommentDBContext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<UserDBContext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddDbContext<CategoryDBcontext>(opt =>
                                               opt.UseSqlServer(ServerCon));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
