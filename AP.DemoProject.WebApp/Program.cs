using AP.DemoProject.Application.Extensions;
using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Infrastructure.Extensions;
using AP.DemoProject.Infrastructure.Services;
using AP.DemoProject.WebApp.Components;
using Microsoft.AspNetCore.Components;

namespace AP.DemoProject.WebApp {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddControllers();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAntiforgery();
            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
