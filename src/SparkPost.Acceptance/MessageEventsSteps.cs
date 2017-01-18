using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SparkPost.Acceptance
{
    [Binding]
    public class MessageEventsSteps
    {
        [When(@"I ask for samples of '(.*)'")]
        public void WhenIAskForSamplesOf(string events)
        {
            var client = ScenarioContext.Current.Get<IClient>();

            MessageEventSampleResponse response = null;

            Task.Run(async () => { response = await client.MessageEvents.SamplesOf(events); }).Wait();

            ScenarioContext.Current.Set(response);
            ScenarioContext.Current.Set<Response>(response);
        }
    }
}