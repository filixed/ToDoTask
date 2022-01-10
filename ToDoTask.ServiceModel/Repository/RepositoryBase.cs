using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.ServiceModel.Repository
{
    public class RepositoryBase : IDisposable
    {
        public IDbConnectionFactory DbFactory { get; set; }

        IDbConnection db;
        protected IDbConnection Db
        {
            get { return db ?? (db = DbFactory.Open()); }
        }

        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }

    }
}
