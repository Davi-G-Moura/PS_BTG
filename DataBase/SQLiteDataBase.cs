using CadastroClientes.Models;
using SQLite;

namespace CadastroClientes.DataBase
{
    public class SQLiteDataBase
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBase(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Cliente>().Wait();

        }

        public Task<int> Insert(Cliente cliente)
        { 
            return _conn.InsertAsync(cliente);
        }

        public Task<List<Cliente>> Update(Cliente cliente)
        {
            string sql = "UPDATE CLIENTE SET Name=?, Lastname=?, Age=?, Address=? WHERE Id=?";

            return _conn.QueryAsync<Cliente>(sql, cliente.Name, cliente.Lastname, cliente.Age, cliente.Address, cliente.Id);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Cliente>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Cliente>> GetAll()
        {
           return _conn.Table<Cliente>().ToListAsync();
        }

        public Task<List<Cliente>> Search(string q)
        {
            string sql = "SELECT * FROM CLIENTE WHERE Name LIKE '%" + q + "%'";

            return _conn.QueryAsync<Cliente>(sql);
        }
    }
}
