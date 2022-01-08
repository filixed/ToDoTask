using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Responses.ToDoResponses;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route ("/gettodos", "GET")]
    public class ToDoGetAllRequest : IReturn<ToDoGetAllResponse>
    {

    }
}
