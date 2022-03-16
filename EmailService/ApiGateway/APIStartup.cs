using Ocelot.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class APIStartup : Startup
    {
        public APIStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddMvcCore().AddApiExplorer();
            
            services.AddOcelot();
            services.AddSwaggerForOcelot(Configuration);

            services.AddCors();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseWebSockets();

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            })
            .UseOcelot()
            .Wait();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
