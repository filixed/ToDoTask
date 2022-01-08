using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route ("/getone/{Id}", "GET")]
    public class ToDoGetOneRequest : IReturn<ToDoGetOneRequest>
    {
        public int Id { get; set; }
    }
}
