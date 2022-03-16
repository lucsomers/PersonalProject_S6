using ApiGateway.Setup;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiGateway
{
    public class ServiceStartup : Startup
    {
            protected readonly SwaggerSetup swaggerSetup;
            //protected readonly RabbitMQSetup rabbitMQSetup;

            //private readonly DbContextsSetup dbContextsSetup;

            public ServiceStartup(IConfiguration configuration) : base(configuration)
            {
                //dbContextsSetup = new DbContextsSetup();
                //rabbitMQSetup = new RabbitMQSetup();
                swaggerSetup = new SwaggerSetup();
            }

            //This method gets called by the runtime. Use this method to add services to the container.
            public override void ConfigureServices(IServiceCollection services)
            {
                base.ConfigureServices(services);

               // dbContextsSetup.Setup(services, Configuration);

                SetupCors(services);
            }

            //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                base.Configure(app, env);
            }

            private void SetupCors(IServiceCollection services)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowMyOrigin",
                    builder => builder.AllowAnyOrigin());
                });
            }
    }
}
