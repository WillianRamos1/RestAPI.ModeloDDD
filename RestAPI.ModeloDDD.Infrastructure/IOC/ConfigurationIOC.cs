using Autofac;
using RestAPI.ModeloDDD.Application;
using RestAPI.ModeloDDD.Application.Contratos;
using RestAPI.ModeloDDD.Domain.Contratos;
using RestAPI.ModeloDDD.Domain.Services;
using RestAPI.ModeloDDD.Domain.Services.Contratos;
using RestAPI.ModeloDDD.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Infrastructure.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<ProdutoRepository>().As<IProdutoRepository>();
        }
    }
}
