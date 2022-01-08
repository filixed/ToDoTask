using ServiceStack;
using ToDoTask.ServiceModel.Responses.ToDoResponses;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route ("/setdone/{Id}", "PUT")]
    public class ToDoSetDoneRequest : IReturn<ToDoSetDoneResponse>
    {
        public int Id { get; set; }
    }
}
