using System.Threading.Tasks;

namespace SparkPost.RequestSenders
{
    public class SyncRequestSender : IRequestSender
    {
        private readonly IRequestSender requestSender;

        public SyncRequestSender(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        public virtual Task<Response> Send(Request request)
        {
            Response response = null;

            Task.Run(async () => { response = await requestSender.Send(request); }).Wait();

            return Task.FromResult(response);
        }
    }
}