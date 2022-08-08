using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Api.Queries.Abstract;
using Checkout.Api.Queries.ViewModel;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Checkout.Api.Queries
{
    internal class BasketQueris : IBasketQueries
    {
        private const string GetBasketsSqlQuery = @"SELECT * from baskets";
        private const string GetBasketSqlQuery = @"SELECT * from baskets WHERE Id = @BasketId";

        private readonly string connectionString;

        public BasketQueris(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<BasketViewModel> GetBasketAsyc(Guid basketId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                return await connection.QueryFirstAsync<BasketViewModel>(GetBasketSqlQuery,
                    param: new {@BasketId = basketId});
            }
        }

        public async Task<IEnumerable<BasketViewModel>> GetBasketsAsyc()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<BasketViewModel>(GetBasketsSqlQuery);
            }
        }
    }
}
