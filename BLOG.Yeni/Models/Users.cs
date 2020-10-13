using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLOG.Yeni.Models
{
    public class Users
    {
        public ObjectId _id { get; set; }

         public string User_email { get; set; }

        public string User_Name { get; set; }
        public string User_Password { get; set; }

       
        
    }
}
