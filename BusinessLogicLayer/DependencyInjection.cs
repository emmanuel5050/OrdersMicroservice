using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Validators;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.HttpClients;


namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //TO DO: Add business logic layer services into the IoC container
        services.AddValidatorsFromAssemblyContaining<OrderAddRequestValidator>();

        services.AddAutoMapper(typeof(OrderAddRequestToOrderMappingProfile).Assembly);

        services.AddScoped<IOrdersService, OrdersService>();
        return services;
    }
    public static IServiceCollection RegisterServicesHttpClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHttpClient<UsersMicroserviceClient>(client =>
        {
            client.BaseAddress = new Uri(configuration["UsersMicroService:Url"]);
            client.DefaultRequestHeaders.Clear();
        });
        return serviceCollection;
    }
}
