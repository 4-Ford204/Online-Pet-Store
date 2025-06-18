namespace Customer.API.Abstractions.Registrations
{
    public interface IRegistration
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
