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
            var assemblyServices = Assembly.Load("LearnAdmin.Services");
            builder.RegisterAssemblyTypes(assemblyServices).AsImplementedInterfaces();
            var assemblyREpository = Assembly.Load("LearnAdmin.Repositories");
            builder.RegisterAssemblyTypes(assemblyREpository).AsImplementedInterfaces();
        }
    }
}

