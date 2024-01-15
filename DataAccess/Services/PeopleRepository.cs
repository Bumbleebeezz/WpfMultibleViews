using System.Security;
using Common.DTOs;
using DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.Services;

public class PeopleRepository
{
    private readonly IMongoCollection<Person> _people;

    public PeopleRepository()
    {
        var hostName = "localhost";
        var port = "27017";
        var databaseName = "PeopleDb";

        var client = new MongoClient($"mongodb://{hostName}:{port}");

        var database = client.GetDatabase(databaseName);

        _people = database.GetCollection<Person>("People",new MongoCollectionSettings(){AssignIdOnInsert = true});
    }

    public void AddPerson(PersonRecord personRecord)
    {
        var newPerson = new Person()
        {
            FirstName = personRecord.FirstName,
            LastName = personRecord.LastName
        };
        
        _people.InsertOne(newPerson);
    }

    public List<PersonRecord> GetAllPeople()
    {
        var filter = Builders<Person>.Filter.Empty; ;
        var allPeople = _people
            .Find(_ => true)
            .ToList()
            .Select(p => new PersonRecord(p.ID.ToString(),p.FirstName,p.LastName));

        return allPeople.ToList();
    }

    public PersonRecord UpdatePersonLastname(string ID, string newLastName)
    {
        var filter = Builders<Person>.Filter.Eq("_id", ObjectId.Parse(ID));
        var update = Builders<Person>.Update.Set(person => person.LastName, newLastName);

        _people.UpdateOne(filter, update);

        var updatedPerson = _people.Find(filter).FirstOrDefault();
        return new PersonRecord(updatedPerson.ID.ToString(), updatedPerson.FirstName, updatedPerson.LastName);
    }

    public void DeletePerson(string ID)
    {
        var filter = Builders<Person>.Filter.Eq("_id", ObjectId.Parse(ID));
        _people.DeleteOne(filter);
    }
}