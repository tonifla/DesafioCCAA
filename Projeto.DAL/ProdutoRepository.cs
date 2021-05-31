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
    public class ProdutoRepository
    {
        private string connectionString;

        public ProdutoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["desafio"].ConnectionString;
        }

        public void Insert(Produto produto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " insert into Produto(Nome, Descricao, DataValidade, DataFabricacao, Preco, IdCategoria, IdFornecedor) " +
                               " values(@Nome, @Descricao, @DataValidade, @DataFabricacao, @Preco, @IdCategoria, @IdFornecedor)";

                conn.Execute(query, produto);
            }
        }

        public void Update(Produto produto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " update Produto " +
                               " set Nome = @Nome, " +
                               "     Descricao = @Descricao, " +
                               "     DataValidade = @DataValidade, " +
                               "     DataFabricacao = @DataFabricacao, " +
                               "     Preco = @Preco, " +
                               "     IdCategoria = @IdCategoria, " +
                               "     IdFornecedor = @IdFornecedor " +
                               " where IdProduto = @IdProduto ";

                conn.Execute(query, produto);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " delete from Produto where IdProduto = @IdProduto ";

                conn.Execute(query, new { idProduto = id });
            }
        }

        public List<Produto> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Produto ";

                return conn.Query<Produto>(query).ToList();
            }
        }

        public Produto SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Produto where IdProduto = @IdProduto ";

                return conn.QuerySingleOrDefault<Produto>(query, new { IdProduto = id });
            }
        }
    }
}