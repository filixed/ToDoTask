using ServiceStack;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Responses.ToDoResponses
{
    public class ToDoGetOneResponse
    {
        public ToDo Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
