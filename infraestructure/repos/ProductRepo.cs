using System.Data;
using Adapter;
using Dapper;
using Entities;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Compilers;

namespace db
{
    public class Repository
    {
        private readonly IDbConnection dbConnection;
        private readonly Compiler compiler;

        public Repository(string connection)
        {
            dbConnection = new MySqlConnection(connection);
            compiler = new MySqlCompiler();
        }

        public async Task<List<DomainProduct>> ObtenerProductos()
        {
            var consulta = compiler.Compile(new Query("Productos"));
            return (await dbConnection.QueryAsync<DomainProduct>(consulta.Sql, consulta.NamedBindings)).ToList();
        }

        public async Task<DomainProduct?> ObtenerProductoPorId(int id_producto)
        {
            var consulta = compiler.Compile(new Query("Productos").Where("id_producto", id_producto));
            return await dbConnection.QueryFirstOrDefaultAsync<DomainProduct>(consulta.Sql, consulta.NamedBindings);
        }

        public async Task CrearProducto(DomainProduct producto)
        {
            var consulta = compiler.Compile(new Query("Productos").AsInsert(producto));
            await dbConnection.ExecuteAsync(consulta.Sql, consulta.NamedBindings);
        }

        public async Task ActualizarProducto(DomainProduct producto)
        {
            var consulta = compiler.Compile(new Query("Productos").Where("id_producto", producto.id_producto).AsUpdate(producto));
            await dbConnection.ExecuteAsync(consulta.Sql, consulta.NamedBindings);
        }

        public async Task EliminarProducto(int id_producto)
        {
            var consulta = compiler.Compile(new Query("Productos").Where("id_producto", id_producto).AsDelete());
            await dbConnection.ExecuteAsync(consulta.Sql, consulta.NamedBindings);
        }
    }
}