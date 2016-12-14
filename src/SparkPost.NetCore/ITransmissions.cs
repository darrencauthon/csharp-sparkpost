using System.Threading.Tasks;

namespace SparkPost
{
    /// <summary>
    /// Provides access to the transmissions resource of the SparkPost API.
    /// </summary>
    public interface ITransmissions
    {
        /// <summary>
        /// Sends an email transmission.
        /// </summary>
        /// <param name="transmission">The properties of the transmission to send.</param>
        /// <returns>The response from the API.</returns>
        Task<SendTransmissionResponse> Send(Transmission transmission);

        /// <summary>
        /// Retrieves an email transmission.
        /// </summary>
        /// <param name="transmissionId">The id of the transmission to retrieve.</param>
        /// <returns>The response from the API.</returns>
        Task<RetrieveTransmissionResponse> Retrieve(string transmissionId);

        /// <summary>
        /// Lists recent email transmissions.
        /// </summary>
        /// <returns>The response from the API.</returns>
        Task<ListTransmissionResponse> List();
    }
}