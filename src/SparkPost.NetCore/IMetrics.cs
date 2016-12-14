using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    public interface IMetrics
    {
        /// <summary>
        /// Provides high-level summary of aggregate metrics.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverability(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByDomain(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by sending IP over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityBySendingIp(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by IP pool over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByIpPool(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by sending domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityBySendingDomain(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by subaccount over the time window specified. Please note that master account events will be returned grouped by the subaccount_id field containing the value 0.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityBySubaccount(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by campaign over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByCampaign(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by template over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByTemplate(object query);
        /// <summary>
        /// Provides aggregate metrics grouped by watched domain over the time window specified.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByWatchedDomain(object query);
        /// <summary>
        /// Provides deliverability metrics ordered by a precision of time.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliverabilityByTimeSeries(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the bounce reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetBounceReasons(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the domain and bounce reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetBounceReasonsByDomain(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to bounce events, grouped by the bounce classification.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetBounceClassifications(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to rejection events, grouped by the rejection reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetRejectionReasons(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to rejection events, grouped by the domain and rejection reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetRejectionReasonsByDomain(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to delay events, grouped by the delay reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDelayReasons(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to delay events, grouped by the domain and delay reasons.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDelayReasonsByDomain(object query);
        /// <summary>
        /// Provides deliverability metrics, specific to engagement events (clicks/opens);, grouped by the link name or URL.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetEngagementDetails(object query);
        /// <summary>
        /// Provides aggregate count of deliveries grouped by the attempt number.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetMetricsResponse> GetDeliveriesByAttempt(object query);

        /// <summary>
        /// Returns a list of domains that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetDomains();
        /// <summary>
        /// Returns a list of domains that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetDomains(object metricsSimpleQuery);
        /// <summary>
        /// Returns a list of IP pools that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetIpPools();
        /// <summary>
        /// Returns a list of IP pools that the Metrics API contains data on.   
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetIpPools(object metricsSimpleQuery);
        /// <summary>
        /// Returns a list of sending IPs that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetSendingIps();
        /// <summary>
        /// Returns a list of sending IPs that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetSendingIps(object metricsSimpleQuery);
        /// <summary>
        /// Returns a list of campaigns that the Metrics API contains data on.
        /// </summary>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetCampaigns();
        /// <summary>
        /// Returns a list of campaigns that the Metrics API contains data on.
        /// </summary>
        /// <param name="metricsSimpleQuery"></param>
        /// <returns></returns>
        Task<GetMetricsResourceResponse> GetCampaigns(object metricsSimpleQuery);

    }
}
