using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BLOG.Yeni.Models
{
    public class Errors

    {

        public ObjectId _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string _idString { get; set; }
        public int Category_id { get; set; }
        public int Error_id { get; set; }
     
        public string Error_Name { get; set; }
        public string Solution { get; set; }
    }
}
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using System.ComponentModel.DataAnnotations;


//namespace WebApplication2.Models
//{
//    public class Errors
//    {
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string Id { get; set; }

//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string Error_id { get; set; }

//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string Category_id { get; set; }

//        [BsonElement("Error_name")]
//        [Required]
//        public  string  Error_name { get; set; }

//        [BsonElement("Solution")]
//        [Required]
//        public string Solution { get; set; }
//    }
//}
