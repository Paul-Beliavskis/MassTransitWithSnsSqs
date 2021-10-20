//using MassTransit.Topology;

//namespace Mecca.Services.Common.NameFormatters
//{
//    public class TopicNameFormatter : IEntityNameFormatter
//    {
//        public string FormatEntityName<T>()
//        {
//            var eventClassName = typeof(T).Name;

//            var eventTopicName = "order_updated.fifo";

//            return eventTopicName;
//        }
//    }
//}

using MassTransit.Topology;
using System.Text.RegularExpressions;

namespace Mecca.Services.Common.NameFormatters
{
    public class TopicNameFormatter : IEntityNameFormatter
    {
        public string FormatEntityName<T>()
        {
            var eventClassName = typeof(T).Name;

            var eventTopicName = Regex.Replace(eventClassName, "([A-Z])(?![A-Z])", "-$1").Trim('-').ToLower() + ".fifo";

            return eventTopicName;
        }
    }
}

