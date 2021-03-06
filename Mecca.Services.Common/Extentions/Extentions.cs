using MassTransit;
using MassTransit.AmazonSqsTransport;
using Mecca.Services.Common.NameFormatters;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mecca.Services.Common.Extentions
{
    public static class Extentions
    {
        public static IServiceCollection AddMeccaConsumers(this IServiceCollection serviceCollection, string serviceName)
        {
            serviceCollection.AddMassTransit(x =>
                {
                    x.AddConsumers(Assembly.GetEntryAssembly());

                    x.UsingAmazonSqs((context, cfg) =>
                    {

                        cfg.Host("ap-southeast-2", h =>
                        {

                        });

                        cfg.MessageTopology.SetEntityNameFormatter(new TopicNameFormatter());

                        cfg.ConfigureEndpoints(context, new QueueNameFormatter(serviceName));
                    });

                    x.AddConfigureEndpointsCallback((name, cfg) =>
                    {
                        if (cfg is IAmazonSqsReceiveEndpointConfigurator configurator)
                        {
                            configurator.ConcurrentMessageLimit = 100;
                            configurator.QueueAttributes.Add("ContentBasedDeduplication", true);
                        }
                    });
                });

            serviceCollection.AddMassTransitHostedService();

            return serviceCollection;
        }
    }
}
