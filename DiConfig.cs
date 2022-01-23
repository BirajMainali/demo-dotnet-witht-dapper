using DapperDemo.Providers;
using DapperDemo.Providers.Interface;
using DapperDemo.Repositories;
using DapperDemo.Repositories.Interface;
using DapperDemo.Services;
using DapperDemo.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DapperDemo
{
    public static class DiConfig
    {
        public static IServiceCollection UseDapperDemoWeb(this IServiceCollection services)
        {
            services.AddScoped<ISqlConnectionProvider, SqlConnectionProvider>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}