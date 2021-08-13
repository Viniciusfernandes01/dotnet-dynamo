using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSClient.Database
{
    public abstract class DynamoAbstract<T> where T : class, new()
    {
        private readonly IDynamoDBContext context;

        private Amazon.DynamoDBv2.AmazonDynamoDBClient amazonDbClient;

        //protected DynamoAbstract(IDynamoDBContext context)
        protected DynamoAbstract()
        {
            //this.context = context;
            amazonDbClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient(awsAccessKeyId: "", awsSecretAccessKey: "", Amazon.RegionEndpoint.USEast2);
            context = new DynamoDBContext(amazonDbClient);
        }

        protected async Task<List<T>> Scan()
        {
            return await context.ScanAsync<T>(new List<ScanCondition>()).GetRemainingAsync();
        }

        protected async Task<List<T>> QueryByHash(object hashKey)
        {
            return await context.QueryAsync<T>(hashKey).GetRemainingAsync();
        }

        protected async Task Save(T obj)
        {
            await context.SaveAsync<T>(obj);
        }
    }
}
