using Amazon.DynamoDBv2.DataModel;
using AWSClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSClient.Database
{
    public class ClientRepository : DynamoAbstract<Client>
    {
        //public ClientRepository(IDynamoDBContext context) : base(context)
        public ClientRepository() : base()
        {
        }

        public async Task<List<Client>> GetAll() => await Scan();

        public async Task<List<Client>> GetById(Guid id)
        {
            return await this.QueryByHash(id);
        }

        public new async Task Save(Client obj) => await base.Save(obj);
    }
}
