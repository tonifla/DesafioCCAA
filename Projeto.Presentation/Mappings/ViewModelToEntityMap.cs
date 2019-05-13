using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<FornecedorCadastroViewModel, Fornecedor>();
            CreateMap<CategoriaCadastroViewModel, Categoria>();
            CreateMap<ProdutoCadastroViewModel, Produto>();

            CreateMap<FornecedorEdicaoViewModel, Fornecedor>();
            CreateMap<CategoriaEdicaoViewModel, Categoria>();
            CreateMap<ProdutoEdicaoViewModel, Produto>();
        }
    }
}