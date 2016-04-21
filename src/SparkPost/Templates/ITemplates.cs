using System.Threading.Tasks;

namespace SparkPost
{
    /// <summary>
    /// Provides access to the templates resource of the SparkPost API.
    /// </summary>
    public interface ITemplates
    {
        /// <summary>
        /// Creates an email template.
        /// </summary>
        /// <param name="template">The properties of the template to create.</param>
        /// <returns>The response from the API.</returns>
        Task<CreateTemplateResponse> Create(Template template);

        /// <summary>
        /// Retrieves an email template.
        /// </summary>
        /// <param name="templateId">The id of the template to retrieve.</param>
        /// <returns>The response from the API.</returns>
        //Task<RetrieveTemplateResponse> Retrieve(string templateId);
    }
}
