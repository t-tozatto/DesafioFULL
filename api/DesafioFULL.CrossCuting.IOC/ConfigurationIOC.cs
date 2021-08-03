using Autofac;
using DesafioFULL.Application.Interface;
using DesafioFULL.Application.Service;
using DesafioFULL.CrossCuting.Interface;
using DesafioFULL.CrossCuting.Map;
using DesafioFULL.Data.Repository;
using DesafioFULL.Domain.Interfaces.Repositorys;
using DesafioFULL.Domain.Interfaces.Services;
using DesafioFULL.Domain.Service;

namespace DesafioFULL.CrossCuting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceParcela>().As<IApplicationServiceParcela>();
            builder.RegisterType<ApplicationServiceTitulo>().As<IApplicationServiceTitulo>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceParcela>().As<IServiceParcela>();
            builder.RegisterType<ServiceTitulo>().As<IServiceTitulo>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryParcela>().As<IRepositoryParcela>();
            builder.RegisterType<RepositoryTitulo>().As<IRepositoryTitulo>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperParcela>().As<IMapperParcela>();
            builder.RegisterType<MapperTitulo>().As<IMapperTitulo>();
            #endregion

            #endregion

        }
    }
}
