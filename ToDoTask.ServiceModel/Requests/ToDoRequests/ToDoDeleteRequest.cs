using ServiceStack;
using ToDoTask.ServiceModel.Responses.ToDoResponses;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route("/deletetodo/{Id}", "DELETE")]
    public class ToDoDeleteRequest : IReturn<ToDoDeleteResponse>
    {
        public int Id { get; set; }
    }
}
