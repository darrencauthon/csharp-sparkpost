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

        /// <summary>
        /// Updates an email template.
        /// </summary>
        /// <param name="templateId">The id of the template to update.</param>
        /// <param name="template">The properties of the template to update (exclude ID from update)</param>
        /// <param name="updatePublished">If true, updates the most recent published template. If the query param is not passed or set to false, it will result in an update to the draft version.</param>
        /// <returns>The response from the API.</returns>
        Task<bool> Update(string templateId, TemplateUpdate template, bool? updatePublished = null);
    }
}
