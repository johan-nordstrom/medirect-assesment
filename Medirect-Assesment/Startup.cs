using Medirect_Assesment.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 

namespace Medirect_Assesment;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
       //services.AddControllers();
        services.AddSingleton<ITradingService, TradingService>();
        services.AddSingleton<IMessageQueueService, RabbitMQService>();
    }

    public void Configure(IApplicationBuilder app)
    {
        //if (env.IsDevelopment())
        //{
            //app.UseDeveloperExceptionPage();
        //}

        /*
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        */
    }
}