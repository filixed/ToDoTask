using ServiceStack;

using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Responses.ToDoResponses;
using ToDoTask.ServiceModel.Types;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ToDoTask.ServiceInterface
{
    public class ToDoServices : Service
    {
        // /addtodo 
        public ToDoCreateResponse Post(ToDoCreateRequest request)
        {
            var todo = new ToDo { TimeOfExpiry = request.TimeOfExpiry,
                Title = request.Title, Description = request.Description, Complete = request.Complete };
            Db.Save(todo);
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
                Results = Db.Select<ToDo>()
            };
        }
        // /getone/{Id}
        public ToDoGetOneResponse Get(ToDoGetOneRequest request)
        {
            var todo = Db.SingleById<ToDo>(request.Id);
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
            var todo = Db.SingleById<ToDo>(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.TimeOfExpiry = request.TimeOfExpiry;
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.Complete = request.Complete;

            Db.Update(todo);

            return new ToDoUpdateResponse
            {
                Result = todo
            };
        }

        // /getincoming/{IncomingFor}

        public ToDoGetSpecificResponse Get(ToDoGetSpecificRequest request)
        {
            switch (request.IncomingFor)
            {
                case "day":
                    return new ToDoGetSpecificResponse
                    {
                        Results = Db.Select<ToDo>("SELECT * FROM to_do WHERE " +
                        "time_of_expiry <= (SELECT CURRENT_TIMESTAMP + '1 day'::interval);")
                    };
                case "week":
                    return new ToDoGetSpecificResponse
                    {
                        Results = Db.Select<ToDo>("SELECT * FROM to_do WHERE " +
                        "time_of_expiry <= (SELECT CURRENT_TIMESTAMP + '7 day'::interval);")

                    };
                default:
                    throw HttpError.NotFound("ToDo not found");
            }
        }

        // /updpercent/{Id}

        public ToDoUpdatePercentResponse Put(ToDoUpdatePercentRequest request)
        {
            var todo = Db.SingleById<ToDo>(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.Complete = request.Complete;
            Db.Update(todo);

            return new ToDoUpdatePercentResponse
            {
                Result = todo
            };
        }

        // /deleteToDo/{Id}

        public ToDoDeleteResponse Delete(ToDoDeleteRequest request)
        {
            var todo = Db.SingleById<ToDo>(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");
            return new ToDoDeleteResponse
            {
                Result = ("Id " + todo.Id + " was deleted")
            };
        }

        // /setdone/{Id}

        public ToDoSetDoneResponse Put(ToDoSetDoneRequest request) 
        { 
            var todo = Db.SingleById<ToDo>(request.Id);
            if (todo == null)
                throw HttpError.NotFound("ToDo not found");

            todo.isDone = true;
            Db.Update(todo);

            return new ToDoSetDoneResponse
            {
                Result = todo
            };
        }
    }
}
