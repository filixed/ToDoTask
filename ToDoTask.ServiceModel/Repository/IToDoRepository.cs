using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Repository
{
    public interface IToDoRepository
    {

        ToDo GetById(int id);
        void Insert(ToDo t);
        public ToDo CreateTodo(ToDoCreateRequest request);
        void Update(ToDo t);
        void Delete(int id);
        List<ToDo> GetAll();
        //Task<List<ToDo>> GetAllAsync();
        List<ToDo> GetIncoming(ToDoGetSpecificRequest request);
    }
}
