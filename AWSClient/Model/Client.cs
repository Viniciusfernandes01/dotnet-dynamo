using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSClient.Model
{
    [DynamoDBTable("ClienteTable")]
    public class Client
    {
        [DynamoDBHashKey]
        public Guid IdClient { get; set; }

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBProperty]
        public string CPF { get; set; }

        [DynamoDBProperty]
        public DateTime BirthDate { get; set; }
    }
}
