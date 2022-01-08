using ServiceStack;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Responses.ToDoResponses
{
    public class ToDoSetDoneResponse
    {
        public ToDo Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
