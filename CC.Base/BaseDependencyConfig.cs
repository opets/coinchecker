using Autofac;
using CC.Base.Configuration;
using CC.Base.Rest;
using CC.Base.Serialization;

namespace CC.Base
{

    public class BaseDependencyConfig
    {
        protected virtual void Load(ContainerBuilder builder)
        {
            // Config
            builder.RegisterType<BaseConfigurationProvider>().As<IConfigurationProvider>().SingleInstance();

            // Serialization
            builder.RegisterType<NewtonJsonConverter>().As<IJsonConverter>().SingleInstance();

            // WebClient
            builder.RegisterType<WebClient>().As<IWebClient>().SingleInstance();
        }

        public IContainer Build()
        {
            ContainerBuilder builder = new ContainerBuilder();

            Load(builder);

            return builder.Build();
        }
    }
}