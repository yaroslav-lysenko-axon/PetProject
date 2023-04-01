using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection serviceCollection = builder.Services;
ConfigureServices(serviceCollection, builder);
serviceCollection.AddEndpointsApiExplorer();
serviceCollection.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo {Title = "Demo API", Version = "v1"});
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

if (!builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

void ConfigureServices(IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
{
    services.AddControllers();
}












