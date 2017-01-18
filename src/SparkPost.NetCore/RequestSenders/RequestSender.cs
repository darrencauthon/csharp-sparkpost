using System.Threading.Tasks;

namespace SparkPost.RequestSenders
{
    public interface IRequestSender
    {
        Task<Response> Send(Request request);
    }

    public class RequestSender : IRequestSender
    {
        private readonly AsyncRequestSender asyncRequestSender;
        private readonly IClient client;
        private readonly SyncRequestSender syncRequestSender;

        public RequestSender(AsyncRequestSender asyncRequestSender, SyncRequestSender syncRequestSender, IClient client)
        {
            this.asyncRequestSender = asyncRequestSender;
            this.syncRequestSender = syncRequestSender;
            this.client = client;
        }

        public Task<Response> Send(Request request)
        {
            return PickTheRequestSender().Send(request);
        }

        private IRequestSender PickTheRequestSender()
        {
            return client.CustomSettings.SendingMode == SendingModes.Sync
                ? syncRequestSender
                : asyncRequestSender as IRequestSender;
        }
    }
}