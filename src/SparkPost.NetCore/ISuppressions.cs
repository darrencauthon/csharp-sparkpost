using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkPost
{
    public interface ISuppressions
    {
        Task<ListSuppressionResponse> List(SuppressionsQuery supppressionsQuery);
        Task<ListSuppressionResponse> List(object query = null);
        Task<ListSuppressionResponse> Retrieve(string email);
        Task<UpdateSuppressionResponse> CreateOrUpdate(IEnumerable<string> emails);
        Task<UpdateSuppressionResponse> CreateOrUpdate(IEnumerable<Suppression> suppressions);
        Task<bool> Delete(string email);
    }
}