using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Repository
{
    public class ToDoRepository  : RepositoryBase, IToDoRepository
    {
        // this probably should't be here
        public ToDo CreateTodo(ToDoCreateRequest request)
        {            
            var todo = new ToDo
            {
                TimeOfExpiry = request.TimeOfExpiry,
                Title = request.Title,
                Description = request.Description,
                Complete = request.Complete
            };
            return todo;
        }

        public void Delete(int id)
        {
            Db.Delete<ToDo>(i => i.Id == id);
        }

        public List<ToDo> GetAll()
        {
            var query = Db.From<ToDo>().OrderBy("Id");
            List<ToDo> results = Db.Select<ToDo>(query);
            return results;
        }

        //public async Task<List<ToDo>> GetAllAsync()
        //{
        //    return await Db.SelectAsync<ToDo>();
        //}

        public ToDo GetById(int id)
        {
            return Db.SingleById<ToDo>(id);
        }

        public List<ToDo> GetIncoming(ToDoGetSpecificRequest request)
        {
            switch (request.IncomingFor)
            {
                case "day":                   
                    {
                        int h = DateTime.Now.Hour;
                        DateTime startDay = DateTime.Today.AddHours(-h);
                        DateTime endDay = DateTime.Today.AddDays(1).AddTicks(-1);
                        return Db.Select<ToDo>(t => t.TimeOfExpiry >= startDay
                        && t.TimeOfExpiry <= endDay );
                    };
                case "nextday":
                    {
                        int h = DateTime.Now.Hour;
                        DateTime startDay = DateTime.Today.AddHours(-h).AddDays(2);
                        DateTime endDay = DateTime.Today.AddDays(2).AddTicks(-1);
                        return Db.Select<ToDo>(t => t.TimeOfExpiry >= startDay
                        && t.TimeOfExpiry <= endDay);
                    };
                case "week":                    
                    {
                        int h = DateTime.Now.Hour;
                        DateTime startDay = DateTime.Today.AddHours(-h);
                        DateTime endDay = DateTime.Today.AddDays(7).AddTicks(-1);
                        return Db.Select<ToDo>(t => t.TimeOfExpiry >= startDay
                        && t.TimeOfExpiry <= endDay);

                    };
                default:
                    throw HttpError.BadRequest("ToDo not found");
            }
        }

        public void Insert(ToDo todo)
        {
            Db.Save(todo);
        }


        public void Update(ToDo t)
        {
            Db.Update(t);
        }
    }
}
