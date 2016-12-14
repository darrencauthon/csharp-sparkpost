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
        /// <param name="draft">If true, returns the most recent draft template. If false, returns the most recent published template. If not provided, returns the most recent template version regardless of draft or published.</param>
        /// <returns>The response from the API.</returns>
        Task<RetrieveTemplateResponse> Retrieve(string templateId, bool? draft = null);

        Task<RetrieveTemplatesResponse> List();

        Task<bool> Delete(string templateId);
    }
}
