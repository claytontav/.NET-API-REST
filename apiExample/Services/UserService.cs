using apiExample.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace apiExample.Services
{
    
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<UserModel>(settings.UserCollectionsName);
        }

        public List<UserModel> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public UserModel Get(string id)
        {
            return _users.Find<UserModel>(user => user.Id == id).FirstOrDefault();
        }

        public UserModel Create(UserModel newUser)
        {
            _users.InsertOne(newUser);
            return newUser;
        }

        public void Update(string id, UserModel newUser)
        {
            _users.ReplaceOne(user => user.Id == id, newUser);
        }

        public void Remove(UserModel newUser)
        {
            _users.DeleteOne(user => user.Id == newUser.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }
    }
}