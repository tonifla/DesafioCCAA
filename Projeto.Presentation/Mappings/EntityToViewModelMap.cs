using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Fornecedor, FornecedorConsultaViewModel>();
            CreateMap<Categoria, CategoriaConsultaViewModel>();
            CreateMap<Produto, ProdutoConsultaViewModel>();

            CreateMap<Fornecedor, FornecedorEdicaoViewModel>();
            CreateMap<Categoria, CategoriaEdicaoViewModel>();
            CreateMap<Produto, ProdutoEdicaoViewModel>();
        }
    }
}