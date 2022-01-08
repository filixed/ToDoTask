using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.ServiceModel.Types
{
    public class ToDo
    {
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime TimeOfExpiry { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Complete { get; set; }
        public bool isDone { get; set; }
        
        public ToDo()
        {
            this.DateTime = DateTime.Now;
            this.isDone = false;

        }

    }
}


