using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Repository;

namespace EmployeeManagement.Infrastructure
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
        {


            services.AddScoped
            <IEmployeeRepository,
            EmployeeRepository>();



            return services;

        }

    }
}
