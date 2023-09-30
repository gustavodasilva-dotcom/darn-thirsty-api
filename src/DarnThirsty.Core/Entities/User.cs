using MongoDB.Bson;

namespace DarnThirsty.Core.Entities;

public class User
{
    public ObjectId id { get; set; }

    public string name { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public bool active { get; set; }
}