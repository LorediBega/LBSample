using LBSample.Domain;
using LBSample.Domain.Concrete;
using LBSample.Domain.Interface;
using LBSample.Repository;
using LBSample.Repository.Concrete;
using LBSample.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LBSample.DependencyInjection
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddScoped<ITestRepository, TestRepository>();

            return services;
        }

        public static IServiceCollection AddDomainConfig(this IServiceCollection services)
        {
            services.AddScoped<ITestDomain, TestDomain>();

            return services;
        }

        public static IServiceCollection AddProviderConfig(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
