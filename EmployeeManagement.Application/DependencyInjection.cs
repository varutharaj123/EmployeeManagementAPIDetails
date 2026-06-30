using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;


namespace EmployeeManagement.Application;


public static class DependencyInjection
{


    public static IServiceCollection AddApplication(
    this IServiceCollection services)
    {


        services.AddScoped
        <IEmployeeService, EmployeeService>();


        return services;

    }


}