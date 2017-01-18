using System.Net.Http;
using System.Threading.Tasks;

namespace SparkPost.RequestMethods
{
    public abstract class RequestMethod : IRequestMethod
    {
        public bool CanExecute(Request request)
        {
            return (request.Method ?? "").ToLower().StartsWith(GetType().Name.ToLower());
        }

        public abstract Task<HttpResponseMessage> Execute(Request request);
    }
}