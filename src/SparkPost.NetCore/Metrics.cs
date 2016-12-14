using SparkPost.RequestSenders;
using SparkPost.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public class Metrics: IMetrics
    {
        private readonly IClient client;
        private readonly IRequestSender requestSender;

        public Metrics(IClient client, IRequestSender requestSender)
        {            
            this.client = client;
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Provides high-level summary of aggregate metrics.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverability(object query)
        {
            return await GetMetrics("deliverability", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByDomain(object query)
        {
            return await GetMetrics("deliverability/domain", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by sending IP over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityBySendingIp(object query)
        {
            return await GetMetrics("deliverability/sending-ip", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by IP pool over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByIpPool(object query)
        {
            return await GetMetrics("deliverability/ip-pool", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by sending domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityBySendingDomain(object query)
        {
            return await GetMetrics("deliverability/sending-domain", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by subaccount over the time window specified. Please note that master account events will be returned grouped by the subaccount_id field containing the value 0.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityBySubaccount(object query)
        {
            return await GetMetrics("deliverability/subaccount", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by campaign over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByCampaign(object query)
        {
            return await GetMetrics("deliverability/campaign", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by template over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByTemplate(object query)
        {
            return await GetMetrics("deliverability", query);
        }

        /// <summary>
        /// Provides aggregate metrics grouped by watched domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByWatchedDomain(object query)
        {
            return await GetMetrics("deliverability/watched-domain", query);
        }

        /// <summary>
        /// Provides deliverability metrics ordered by a precision of time.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliverabilityByTimeSeries(object query)
        {
            return await GetMetrics("deliverability/time-series", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the bounce reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetBounceReasons(object query)
        {
            return await GetMetrics("deliverability/bounce-reason", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the domain and bounce reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetBounceReasonsByDomain(object query)
        {
            return await GetMetrics("deliverability/bounce-reason/domain", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the bounce classification.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetBounceClassifications(object query)
        {
            return await GetMetrics("deliverability/bounce-classification", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to rejection events, grouped by the rejection reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetRejectionReasons(object query)
        {
            return await GetMetrics("deliverability/rejection-reason", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to rejection events, grouped by the domain and rejection reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetRejectionReasonsByDomain(object query)
        {
            return await GetMetrics("deliverability/rejection-reason/domain", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to delay events, grouped by the delay reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDelayReasons(object query)
        {
            return await GetMetrics("deliverability/delay-reason", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to delay events, grouped by the domain and delay reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDelayReasonsByDomain(object query)
        {
            return await GetMetrics("deliverability/delay-reason/domain", query);
        }

        /// <summary>
        /// Provides deliverability metrics, specific to engagement events (clicks/opens), grouped by the link name or URL.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetEngagementDetails(object query)
        {
            return await GetMetrics("deliverability/link-name", query);
        }

        /// <summary>
        /// Provides aggregate count of deliveries grouped by the attempt number.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<GetMetricsResponse> GetDeliveriesByAttempt(object query)
        {
            return await GetMetrics("deliverability/attempt", query);
        }

        /// <summary>
        /// Returns a list of domains that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetDomains()
        {
            return await GetDomains(null);
        }

        /// <summary>
        /// Returns a list of domains that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetDomains(object metricsSimpleQuery)
        {
            return await GetMetricsResource("domains", metricsSimpleQuery);
        }

        /// <summary>
        /// Returns a list of IP pools that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetIpPools()
        {
            return await GetIpPools(null);
        }

        /// <summary>
        /// Returns a list of IP pools that the Metrics API contains data on.   
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetIpPools(object metricsSimpleQuery)
        {
            return await GetMetricsResource("ip-pools", metricsSimpleQuery);
        }

        /// <summary>
        /// Returns a list of sending IPs that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetSendingIps()
        {
            return await GetSendingIps(null);
        }

        /// <summary>
        /// Returns a list of sending IPs that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetSendingIps(object metricsSimpleQuery)
        {
            return await GetMetricsResource("sending-ips", metricsSimpleQuery);            
        }

        /// <summary>
        /// Returns a list of campaigns that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetCampaigns()
        {
            return await GetCampaigns(null);
        }

        /// <summary>
        /// Returns a list of campaigns that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        public async Task<GetMetricsResourceResponse> GetCampaigns(object metricsSimpleQuery)
        {
            return await GetMetricsResource("campaigns", metricsSimpleQuery);
        }

        private async Task<GetMetricsResourceResponse> GetMetricsResource(string resourceName, object query)
        {
            var response = await GetApiResponse(resourceName, query);
            dynamic content = Jsonification.DeserializeObject<dynamic>(response.Content);

            var result = new GetMetricsResourceResponse(response);
            result.Results = ConvertToStrings(content.results, resourceName);

            return result;            
        }

        private async Task<GetMetricsResponse> GetMetrics(string relUrl, object query)
        {
            var response = await GetApiResponse(relUrl, query);
            dynamic content = Jsonification.DeserializeObject<dynamic>(response.Content);

            var result = new GetMetricsResponse(response);
            result.Results = ConvertToDictionaries(content.results);

            return result;
        }

        private async Task<Response> GetApiResponse(string relUrl, object query)
        {
            if (query == null)
                query = new { };

            var request = new Request
            {
                Url = $"/api/{client.Version}/metrics/{relUrl}",
                Method = "GET",
                Data = query
            };

            var response = await requestSender.Send(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new ResponseException(response);
            return response;
        }

        private IList<string> ConvertToStrings(dynamic input, string propName)
        {
            var result = new List<string>();
            if (input == null) return result;

            foreach (var item in input[propName])
                result.Add((string)item);
            
            return result;
        }

        private IList<IDictionary<string, object>> ConvertToDictionaries(dynamic input)
        {
            var result = new List<IDictionary<string, object>>();
            if (input == null) return result;

            foreach (var array in input)
            {
                var dict = new Dictionary<string, object>();
                foreach (var item in array)
                {
                    var key = (string)item.Name;
                    var val = item.Value.ToObject<object>();
                    dict.Add(key, val);
                }
                result.Add(dict);
            }

            return result;
        }
    }
}