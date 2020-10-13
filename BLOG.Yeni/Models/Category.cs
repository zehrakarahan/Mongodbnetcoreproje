using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BLOG.Yeni.Models
{
    public class Category
    {
        public ObjectId _id { get; set; }
        public string Category_Name { get; set; }
        [Required]
        public int Category_id { get; set; }
        [Required]
        public int TopCategory { get; set; }

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

//        [BsonId("Category_id")]
//        [Required]
//        public string Category_id { get; set; }

//        [BsonId]("T
//        [Required]
//        public string TopCategory_id { get; set; }



//    }
//}
