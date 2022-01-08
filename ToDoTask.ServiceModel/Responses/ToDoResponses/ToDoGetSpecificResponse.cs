using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Responses.ToDoResponses
{
    public class ToDoGetSpecificResponse
    {
        public List<ToDo> Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
