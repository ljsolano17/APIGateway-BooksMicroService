using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Solution.DO.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    [BsonCollection("Book")]
    public class Book:Document
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }  
        public string Category {  get; set; }
        public string Author { get; set; }

    }
}
