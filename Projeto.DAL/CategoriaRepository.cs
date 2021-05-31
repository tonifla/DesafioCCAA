using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Projeto.Entities;
using Dapper;

namespace Projeto.DAL
{
    public class CategoriaRepository
    {
        private string connectionString;

        public CategoriaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["desafio"].ConnectionString;
        }

        public void Insert(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " insert into Categoria(Nome) " +
                               " values(@Nome)";

                conn.Execute(query, categoria);
            }
        }

        public void Update(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " update Categoria " +
                               " set Nome = @Nome " +
                               " where IdCategoria = @IdCategoria ";


                conn.Execute(query, categoria);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " delete from Categoria where IdCategoria = @IdCategoria ";

                conn.Execute(query, new { idCategoria = id });
            }
        }

        public List<Categoria> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Categoria ";

                return conn.Query<Categoria>(query).ToList();
            }
        }

        public Categoria SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Categoria where IdCategoria = @IdCategoria ";

                return conn.QuerySingleOrDefault<Categoria>(query, new { IdCategoria = id });
            }
        }

        public int SumQuantidadeProdutos(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select sum(IdProduto) Quantidade from Produto where IdCategoria = @IdCategoria ";

                return conn.QuerySingleOrDefault<int?>(query, new { idCategoria = id }) ?? 0;
            }
        }
    }
}