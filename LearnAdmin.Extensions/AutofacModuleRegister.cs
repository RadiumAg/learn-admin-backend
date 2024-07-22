using System.Reflection;
using Autofac;
using LearnAdmin.Extensions.AOP;

namespace LearnAdmin.Extensions
{
	public class AutofacModuleRegister:Autofac.Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<PdfServices>().As<IPdfServices>();
            builder.RegisterType<LearnAdminLogLogAop>();
            var assemblyRepository = Assembly.Load("LearnAdmin.Repositories");
            builder.RegisterAssemblyTypes(assemblyRepository).AsImplementedInterfaces();
            var assemblyServices = Assembly.Load("LearnAdmin.Services");
            builder.RegisterAssemblyTypes(assemblyServices).AsImplementedInterfaces();
        }
    }
}

