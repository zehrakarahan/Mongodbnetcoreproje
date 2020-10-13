using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLOG.Yeni.Models
{
    public class ErrorService
    {


        private readonly IMongoCollection<Errors> errors;

        public ErrorService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Blogverileri"));
            IMongoDatabase database = client.GetDatabase("Blog");
            errors = database.GetCollection<Errors>("Errors");
        }

        public List<Errors> GetAll()
        {
            return errors.Find(error => true).ToList();
        }
        public List<Errors> GetList(int id)
        {
            return errors.Find(error => error.Category_id == id).ToList();
        }
        public Errors Get(ObjectId id)
        {
            return errors.Find(error => error._id == id).FirstOrDefault();
        }

        public Errors GetCategory(int id)
        {
            return errors.Find(error => error.Category_id == id).FirstOrDefault();
        }
        public Errors Create(Errors error)
        {
            errors.InsertOne(error);
            return error;
        }

        public void Update(ObjectId id, Errors errorIn)
        {
            errors.ReplaceOne(error => error._id == id, errorIn);
        }

        public void Remove(Errors errorIn)
        {
            errors.DeleteOne(error => error._id == errorIn._id);
        }
    }


}