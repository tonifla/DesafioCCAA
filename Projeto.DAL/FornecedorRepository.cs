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
    public class FornecedorRepository
    {
        private string connectionString;

        public FornecedorRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["desafio"].ConnectionString;
        }

        public void Insert(Fornecedor fornecedor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " insert into Fornecedor(Nome, Email, Telefone, Cnpj) " +
                               " values(@Nome, @Email, @Telefone, @Cnpj)";

                conn.Execute(query, fornecedor);
            }
        }

        public void Update(Fornecedor fornecedor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " update Fornecedor " +
                               " set Nome = @Nome, " +
                               "     Email = @Email, " +
                               "     Telefone = @Telefone, " +
                               "     Cnpj = @Cnpj " +
                               " where IdFornecedor = @IdFornecedor ";

                conn.Execute(query, fornecedor);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " delete from Fornecedor where IdFornecedor = @IdFornecedor ";

                conn.Execute(query, new { idFornecedor = id });
            }
        }

        public List<Fornecedor> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Fornecedor ";

                return conn.Query<Fornecedor>(query).ToList();
            }
        }

        public Fornecedor SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select * from Fornecedor where IdFornecedor = @IdFornecedor ";

                return conn.QuerySingleOrDefault<Fornecedor>(query, new { IdFornecedor = id });
            }
        }

        public int SumQuantidadeProdutos(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " select sum(IdProduto) Quantidade from Produto where IdFornecedor = @IdFornecedor ";

                return conn.QuerySingleOrDefault<int?>(query, new { idFornecedor = id }) ?? 0;
            }
        }
    }
}