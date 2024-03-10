using crm_minimal.Data;
using crm_minimal.Data.Dao;
using Microsoft.EntityFrameworkCore; 

// ... other using statements

public class Startup
{
    public IConfiguration Configuration { get; } // Make sure you have this

    // ... other code

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationManagementContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("EventManagementDb")));
        
        services.AddScoped<IEventDao, EventDao>(); 



        // ... other service registrations
    }
}
