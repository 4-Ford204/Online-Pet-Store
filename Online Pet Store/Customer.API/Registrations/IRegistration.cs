namespace Customer.API.Registrations
{
    public interface IRegistration
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
