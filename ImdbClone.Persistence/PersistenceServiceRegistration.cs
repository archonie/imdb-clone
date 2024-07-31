using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ImdbClone.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(
        this IServiceCollection services, IConfiguration configuration
        )
    {
        services.AddDbContext<FilmDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("FilmConnectionString"),
                b => b.MigrationsAssembly("ImdbClone.Persistence")));
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IFilmRepository, FilmRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<ICharacterRepository, CharacterRepository>();
        return services;
    }
    
}