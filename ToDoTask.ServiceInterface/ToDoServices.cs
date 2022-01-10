using ServiceStack;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Responses.ToDoResponses;
using ToDoTask.ServiceModel.Repository;


namespace ToDoTask.ServiceInterface
{
    public class ToDoServices : Service
    {
        public IToDoRepository ToDoRepository { get; set; }
        // /addtodo 
        public ToDoCreateResponse Post(ToDoCreateRequest request)
        {
            
            var todo = ToDoRepository.CreateTodo(request);
            ToDoRepository.Insert(todo);
            return new ToDoCreateResponse
            {
                Result = todo
            };
        }
        // /gettodos
        public ToDoGetAllResponse Get(ToDoGetAllRequest request)
        {
            return new ToDoGetAllResponse
            {
                Results = ToDoRepository.GetAll()
            };
        }
        //public async Task<ToDoGetAllResponse> Geta(ToDoGetAllRequest request)
        //{
        //    return new ToDoGetAllResponse
        //    {
        //        Results = await ToDoRepository.GetAllAsync()
        //    };
        //}

        // /getone/{Id}
        public ToDoGetOneResponse Get(ToDoGetOneRequest request)
        {
            var todo = ToDoRepository.GetById(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            return new ToDoGetOneResponse
            {
                Results = todo
            };
        }
        // /updtodoe/{Id}
        public ToDoUpdateResponse Put(ToDoUpdateRequest request)
        {
            var todo = ToDoRepository.GetById(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.TimeOfExpiry = request.TimeOfExpiry;
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.Complete = request.Complete;

            ToDoRepository.Update(todo);

            return new ToDoUpdateResponse
            {
                Result = todo
            };
        }

        // /getincoming/{IncomingFor}

        public ToDoGetSpecificResponse Get(ToDoGetSpecificRequest request)
        {

            return new ToDoGetSpecificResponse
            {
                Results = ToDoRepository.GetIncoming(request)
            };
        }

        // /updpercent/{Id}

        public ToDoUpdatePercentResponse Put(ToDoUpdatePercentRequest request)
        {
            var todo = ToDoRepository.GetById(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.Complete = request.Complete;
            ToDoRepository.Update(todo);

            return new ToDoUpdatePercentResponse
            {
                Result = todo
            };
        }

        // /deleteToDo/{Id}

        public ToDoDeleteResponse Delete(ToDoDeleteRequest request)
        {
            var todo = ToDoRepository.GetById(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            ToDoRepository.Delete(request.Id);

            return new ToDoDeleteResponse
            {
                Result = ("Id " + todo.Id + " was deleted")
            };
        }

        // /setdone/{Id}

        public ToDoSetDoneResponse Put(ToDoSetDoneRequest request) 
        {
            var todo = ToDoRepository.GetById(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.isDone = true;

            ToDoRepository.Update(todo);

            return new ToDoSetDoneResponse
            {
                Result = todo
            };
        }
    }
}
