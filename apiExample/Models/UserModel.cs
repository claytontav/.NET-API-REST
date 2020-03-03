using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiExample.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name { get; set; }

        [BsonElement]
        public string course { get; set; }
    }

    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string UserCollectionsName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IUserDatabaseSettings
    {
        public string UserCollectionsName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}