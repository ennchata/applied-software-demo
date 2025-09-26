using AP.DemoProject.Application.Extensions;
using AP.DemoProject.Infrastructure.Extensions;
using WebAPI.Extensions;

namespace AP.DemoProject.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "LocalOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7104");
                                  });
            });

            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddControllers();

            builder.WebHost.UseUrls("http://0.0.0.0:5000");
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }

            
            
            app.UseErrorHandlingMiddleware();

            //app.UseHttpsRedirection();

            app.UseCors("LocalOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

       
    }
}