using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace SparkPost
{
    public class Templates : ITemplates
    {
        private readonly Client client;
        private readonly RequestSender requestSender;
        private readonly DataMapper dataMapper;

        public Templates(Client client, RequestSender requestSender, DataMapper dataMapper)
        {
            this.client = client;
            this.requestSender = requestSender;
            this.dataMapper = dataMapper;
        }

        public async Task<CreateTemplateResponse> Create(Template template)
        {
            var request = new Request
            {
                Url = $"api/{client.Version}/templates",
                Method = "POST",
                Data = dataMapper.ToDictionary(template)
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);

            var results = JsonConvert.DeserializeObject<dynamic>(response.Content).results;
            return new CreateTemplateResponse()
            {
                Id = results.id,
                //ReasonPhrase = response.ReasonPhrase,
                //StatusCode = response.StatusCode,
                //Content = response.Content,
            };
        }
    }
}
