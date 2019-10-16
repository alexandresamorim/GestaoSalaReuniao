using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.Service;
using SalaReuniao.Dominio.Interface.Repository;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.Service;
using SalaReuniao.Infra.Data.Repository;

namespace SalaReuniao.Infra.IoC
{
    public class InjectionContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Dominio
            builder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
            builder.RegisterType<SalaService>().As<ISalaService>().InstancePerLifetimeScope();
            builder.RegisterType<SalaAgendamentoService>().As<ISalaAgendamentoService>().InstancePerLifetimeScope();

            //Infra Data
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalaRepository>().As<ISalaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalaAgendamentoRepository>().As<ISalaAgendamentoRepository>().InstancePerLifetimeScope();

            //Aplicação
            builder.RegisterType<UsuarioAppService>().As<IUsuarioAppService>().InstancePerLifetimeScope();
            builder.RegisterType<SalaAppService>().As<ISalaAppService>().InstancePerLifetimeScope();
            builder.RegisterType<SalaAgendamentoAppService>().As<ISalaAgendamentoAppService>().InstancePerLifetimeScope();


            var locatorBuilder = new ContainerBuilder();
            locatorBuilder.RegisterType<SalaAgendamentoService>().As<ISalaAgendamentoService>().InstancePerLifetimeScope();
            locatorBuilder.RegisterType<SalaAgendamentoRepository>().As<ISalaAgendamentoRepository>().InstancePerLifetimeScope();

            locatorBuilder.RegisterType<SalaService>().As<ISalaService>().InstancePerLifetimeScope();
            locatorBuilder.RegisterType<SalaRepository>().As<ISalaRepository>().InstancePerLifetimeScope();

            locatorBuilder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
            locatorBuilder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();

            var container = locatorBuilder.Build();
            var locator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

        }

    }
}