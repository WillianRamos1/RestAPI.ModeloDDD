using AutoMapper;
using RestAPI.ModeloDDD.Application.Dtos;
using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Application.Helpers
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
