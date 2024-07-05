using System.Reflection;
using Autofac;

namespace LearnAdmin.Extensions
{
	public class AutofacModuleRegister:Autofac.Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<PdfServices>().As<IPdfServices>();
            var assemblyServices = Assembly.Load("LearnAdmin.Services");
            builder.RegisterAssemblyTypes(assemblyServices).AsImplementedInterfaces();
            var assemblyREpository = Assembly.Load("LearnAdmin.Repositories");
            builder.RegisterAssemblyTypes(assemblyREpository).AsImplementedInterfaces();
        }
    }
}

