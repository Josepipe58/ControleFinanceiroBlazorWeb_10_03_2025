using Application.Abstractions;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IAnoService, AnoService>();
            services.AddScoped<IFiltrarCategoriaService, FiltrarCategoriaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IAnoRepository, AnoRepository>();
            services.AddScoped<IFiltrarCategoriaRepository, FiltrarCategoriaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            return services;
        }
    }
}
