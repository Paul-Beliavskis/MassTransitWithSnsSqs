using MassTransit;
using System.Text.RegularExpressions;

namespace Mecca.Services.Common.NameFormatters
{
    class QueueNameFormatter : IEndpointNameFormatter
    {
        private readonly string _servicename;

        public QueueNameFormatter(string serviceName)
        {
            _servicename = serviceName;
        }

        public string Message<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public string SanitizeName(string name)
        {
            throw new System.NotImplementedException();
        }

        public string TemporaryEndpoint(string tag)
        {
            throw new System.NotImplementedException();
        }

        string IEndpointNameFormatter.CompensateActivity<T, TLog>()
        {
            throw new System.NotImplementedException();
        }

        string IEndpointNameFormatter.Consumer<T>()
        {
            var consumerClassName = typeof(T).Name;

            var consumerQueueName = $"{_servicename}{Regex.Replace(consumerClassName, "([A-Z])(?![A-Z])", "-$1")}".ToLower() + ".fifo";

            return consumerQueueName;
        }

        string IEndpointNameFormatter.ExecuteActivity<T, TArguments>()
        {
            throw new System.NotImplementedException();
        }

        string IEndpointNameFormatter.Saga<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
