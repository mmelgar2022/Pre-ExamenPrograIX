using Dapper;
using DapperExtensions;
using DemoDapperAPI.DML;
using DemoDapperAPI.Models;
using System.Data.SqlClient;

namespace DemoDapperAPI.Services
{
    public class ClteService
    {
        private SqlConnection _Conn = new SqlConnection();
        //Instalar Dapper y SQL 
        private static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=localhost;Initial Catalog=ClienteIX; Integrated Security=True; Pooling=False");
        }
        public Clte GetClienteById(int id)
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select 
            var cliente = _Conn.Query<Clte>("SELECT * FROM Cliente").Where(f => f.id == id).ToList();
            return cliente.Count != 0 ? cliente.First() : null;
        }
        public IEnumerable<Clte> GetClientes()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select 
            var clientes = _Conn.Query<Clte>("SELECT * FROM Cliente").ToList();
            return clientes;
        }

        public async Task<IEnumerable<Clte>> GetClientesAsync()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select 
            var clientes = await _Conn.QueryAsync<Clte>("SELECT * FROM Cliente");
            return clientes;
        }

        public void AddClient(Clte cliente)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                var clientes = _Conn.Execute(strInsert, cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddClient(Clte cliente, bool UseDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    _Conn.Insert(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task AddClientAsync(Clte cliente, bool UseDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    await _Conn.InsertAsync(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void UpdateClient(Clte cliente, bool UseDapper = true, bool UseEntity = false)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    _Conn.Update(cliente);
                    _Conn.Close();
                }
                else
                {
                    //TODO
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task UpdateClientAsync(Clte cliente, bool UseDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open(); 
                if (UseDapper)
                {
                    await _Conn.UpdateAsync(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.CreateUpdateStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
