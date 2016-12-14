using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using SparkPost.RequestMethods;

namespace SparkPost
{
    public interface IRequestMethodFinder
    {
        IRequestMethod FindFor(Request request);
    }

    public class RequestMethodFinder : IRequestMethodFinder
    {
        private readonly HttpClient client;
        private readonly IDataMapper dataMapper;

        public RequestMethodFinder(HttpClient client, IDataMapper dataMapper)
        {
            this.client = client;
            this.dataMapper = dataMapper;
        }

        public IRequestMethod FindFor(Request request)
        {
            return new List<IRequestMethod>
            {
                new Delete(client),
                new Post(client),
                new Put(client),
                new Get(client, dataMapper)
            }.First(x => x.CanExecute(request));
        }
    }
}