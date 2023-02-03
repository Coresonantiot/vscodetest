using Autofac;
using HexTest.Application.Interfaces;
using HexTest.Application.Services;

namespace HexTest.Application;

public class DefaultApplicationModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
        //builder.RegisterType<ToDoItemSearchService>().As<IDummyService>().InstancePerLifetimeScope();        
  }
}
