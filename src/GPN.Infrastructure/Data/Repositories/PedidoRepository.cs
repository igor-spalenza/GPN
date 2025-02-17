using Dapper;
using GPN.Domain.Entities;
using GPN.Domain.Interfaces.Repositories;
using GPN.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Infrastructure.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _dbConnection;

        public PedidoRepository(ProjectDataContext context)
        {
            _dbConnection = context.Connection;
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Pedido WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Pedido>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            var sql = "SELECT * FROM Pedido";
            return await _dbConnection.QueryAsync<Pedido>(sql);
        }

        public async Task AddAsync(Pedido pedido)
        {
            var sql = @"
                INSERT INTO Pedido (ClienteId, Status, DataPedido)
                VALUES (@ClienteId, @Status, @DataPedido)";
            await _dbConnection.ExecuteAsync(sql, pedido);
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            var sql = @"
                UPDATE Pedido 
                SET ClienteId = @ClienteId, 
                    Status = @Status 
                WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, pedido);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Pedido WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
