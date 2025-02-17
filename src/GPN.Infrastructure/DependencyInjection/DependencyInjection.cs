using GPN.Domain.Interfaces.Repositories;
using GPN.Infrastructure.Data.Context;
using GPN.Infrastructure.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPN.Application.Interfaces;
using GPN.Application.Services;
using System.Data.SQLite;

namespace GPN.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // Configuração do contexto de dados
            services.AddScoped<IDbConnection>(db => new SQLiteConnection(connectionString));

            // Registro dos repositórios
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

        }
    }
}
