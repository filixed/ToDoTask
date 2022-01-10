using NUnit.Framework;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Testing;
using System.Collections.Generic;
using System.Linq;
using ToDoTask.ServiceInterface;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Responses.ToDoResponses;
using ToDoTask.ServiceModel.Types;


namespace ToDoTask.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;
    public static List<ToDo> SeedData = new[] { 
        new ToDo {TimeOfExpiry=new System.DateTime(2022-01-10), Title="Title", Description="Description", Complete=0},
        new ToDo {TimeOfExpiry=new System.DateTime(2022-01-11), Title="Title2", Description="Description2", Complete=1},
        new ToDo {TimeOfExpiry=new System.DateTime(2022-01-12), Title="Title3", Description="Description3", Complete=2},

    }.ToList();
    public UnitTest()
    {
        appHost = new BasicAppHost().Init();
        appHost.Container.AddTransient<ToDoServices>();
        appHost.Container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(
            "Server=localhost;User Id=postgres;Password=123qwe;Database=TestToDo;Pooling=true;MinPoolSize=0;MaxPoolSize=200",
                    PostgreSqlDialect.Provider));
        using var db = appHost.Resolve<IDbConnectionFactory>().Open();
        db.DropAndCreateTable<ToDo>();
        db.InsertAll(SeedData);
    
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    [Test]
    public void Post_WhenCalled_ReturnsToDo()
    {
        var service = appHost.Container.Resolve<ToDoServices>();

        var response = (ToDoCreateResponse)service.Post(new ToDoCreateRequest { Title = "World" });

        Assert.That(response.Result.Title, Is.EqualTo("World") );
        Assert.That(response.Result.Description, Is.EqualTo(null));
        Assert.That(response.Result.isDone, Is.EqualTo(false));
    }
    [Test]
    public void Get_WhenCalled_ReturnsTodos()
    {
        var service = appHost.Container.Resolve<ToDoServices>();

        ToDoGetAllResponse response = (ToDoGetAllResponse)service.GetAsync(new ToDoGetAllRequest() );

        Assert.AreEqual(3, response.Results.Count);
    }

}