using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Solution.DO.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;

namespace Solution.DO.Objects
{
    [BsonCollection("people")]
    public class Person : Document
    {
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
