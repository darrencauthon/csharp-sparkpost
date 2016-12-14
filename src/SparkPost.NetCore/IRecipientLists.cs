using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkPost
{
    public interface IRecipientLists
    {
        /// <summary>
        /// Creates a recipient list.
        /// </summary>
        /// <param name="recipientList">The properties of the recipientList to create.</param>
        /// <returns>The response from the API.</returns>
        Task<SendRecipientListsResponse> Create(RecipientList recipientList);

        /// <summary>
        /// Retrieves a recipient list.
        /// </summary>
        /// <param name="recipientListsId">The id of the recipient list to retrieve.</param>
        /// <returns>The response from the API.</returns>
        Task<RetrieveRecipientListsResponse> Retrieve(string recipientListsId);

        /// <summary>
        /// Deletes a recipient list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A success or failure.</returns>
        Task<bool> Delete(string id);

        /// <summary>
        /// Updates a recipient list.
        /// </summary>
        /// <param name="recipientList"></param>
        /// <returns></returns>
        Task<UpdateRecipientListResponse> Update(RecipientList recipientList);
    }
}