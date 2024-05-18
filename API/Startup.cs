using BLL.Services;
using crm_minimal.DAL.Repositories;
using crm_minimal.Data;
using Microsoft.EntityFrameworkCore; 

// ... other using statements

public class Startup
{
    public IConfiguration Configuration { get; } // Make sure you have this
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    // ... other code

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<EventContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("EventManagementDb")));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors();
        
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEventService, EventService>();



        // ... other service registrations
    }
}
