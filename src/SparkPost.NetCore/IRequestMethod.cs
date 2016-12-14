using System.Net.Http;
using System.Threading.Tasks;

namespace SparkPost
{
    public interface IRequestMethod
    {
        bool CanExecute(Request request);
        Task<HttpResponseMessage> Execute(Request request);
    }
}