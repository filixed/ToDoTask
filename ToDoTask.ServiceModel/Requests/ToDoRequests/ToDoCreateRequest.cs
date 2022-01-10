using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Responses.ToDoResponses;

namespace ToDoTask.ServiceModel.Requests.ToDoRequests
{
    [Route ("/addtodo", "POST")]
    public class ToDoCreateRequest : IPost, IReturn<ToDoCreateResponse>
    {
        public DateTime TimeOfExpiry { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public int Complete { get; set; }
        public bool isDone { get; set; }

        
    }

   
}
