using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLOG.Yeni.Models
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> category;

        public CategoryService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Blogverileri"));
            IMongoDatabase database = client.GetDatabase("Blog");
            category = database.GetCollection<Category>("Category");
        }
      
        public List<Category> GetAll()
        {
            return category.Find(error => true).ToList();
        }

        public Category Get(int Category_id)
        {
            return category.Find(error => error.Category_id== Category_id).FirstOrDefault();
        }

        public Category Create(Category error)
        {
            category.InsertOne(error);
            return error;
        }

        public void Update(ObjectId id, Category errorIn)
        {
            category.ReplaceOne(error => error._id == id, errorIn);
        }

        public void Remove(Category errorIn)
        {
            category.DeleteOne(error => error._id == errorIn._id);
        }
    }
}
