using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLOG.Yeni.Models
{
    public class UserService
    {
        private readonly IMongoCollection<Users> user;

        public UserService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Blogverileri"));
            IMongoDatabase database = client.GetDatabase("Blog");
            user = database.GetCollection<Users>("Users");
        }

        public List<Users> GetAll()
        {
            return user.Find(user => true).ToList();
        }

        public Users Get(ObjectId id)
        {
            return user.Find(user => user._id == id).FirstOrDefault();
        }
        public Users GetirEmail(string email)
        {
            var veri= user.Find(user => user.User_email == email).FirstOrDefault();
            if (veri == null)
            {
                return null;
            }
            else
            {
                return veri;
            }
        }
        public Users GetirUsername(string username)
        {
            var veri= user.Find(users => users.User_Name == username).FirstOrDefault();
            if (veri==null)
            {
                return null;
            }
            else
            {
                return veri;
            }
            
        }
        public Users Create(Users users)
        {
            user.InsertOne(users);
            return users;
        }

        public void Update(ObjectId id, Users users)
        {
            user.ReplaceOne(users => users._id == id, users);
        }

        public void Remove(Users users)
        {
            user.DeleteOne(users => users._id == users._id);
        }
    }
}
