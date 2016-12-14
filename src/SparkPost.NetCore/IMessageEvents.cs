using System.Threading.Tasks;

namespace SparkPost
{
    public interface IMessageEvents
    {
        Task<ListMessageEventsResponse> List();
        Task<ListMessageEventsResponse> List(object query);
    }
}