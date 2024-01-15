using MongoDB.Bson;

namespace DataAccess.Entities;

public class Person
{
    
    public ObjectId ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}