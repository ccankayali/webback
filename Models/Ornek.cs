using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Ornek
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
    public int Age { get; set; }
}
