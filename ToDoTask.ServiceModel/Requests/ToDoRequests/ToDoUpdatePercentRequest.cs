using ServiceStack;
using ToDoTask.ServiceModel.Responses.ToDoResponses;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route ("/updpercent/{Id}", "PUT")]
    public class ToDoUpdatePercentRequest : IReturn<ToDoUpdatePercentResponse>
    {
        public int Id { get; set; }
        public int Complete { get; set; }
    }
}
