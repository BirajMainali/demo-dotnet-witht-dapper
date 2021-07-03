using DapperDemo.Manager;
using DapperDemo.Manager.Interface;
using DapperDemo.Providers;
using DapperDemo.Providers.Interface;
using DapperDemo.Repository;
using DapperDemo.Repository.Interface;
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
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IEmployeeManager, EmployeeManager>();
            return services;
        }
    }
}