using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kwet_service.DatastoreSettings;
using kwet_service.Entities;
using MongoDB.Driver;

namespace kwet_service.Repositories
{
    public class KweetRepository : IKweetRepository
    {
        private readonly IMongoCollection<Kweet> _kweets;

        public KweetRepository(IKwetstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _kweets = database.GetCollection<Kweet>(settings.KwetCollectionName);
        }

        public async Task<List<Kweet>> Get() =>
            await _kweets.Find(kweet => true).ToListAsync();

        // public async Task<Kweet> GetByEmail(string email) =>
        //     await _kweets.Find(kweet => kweet.Email == email).FirstOrDefaultAsync();
        //
        // public async Task<Kweet> GetByKweetname(string kweetname) =>
        //     await _kweets.Find(kweet => kweet.Kweetname == kweetname).FirstOrDefaultAsync();

        public async Task<Kweet> GetByGuid(Guid id) =>
            await _kweets.Find(kweet => kweet.Id == id).FirstOrDefaultAsync();

        public async Task<Kweet> Get(Guid id) =>
            await _kweets.Find<Kweet>(book => book.Id == id).FirstOrDefaultAsync();

        public async Task<Kweet> Create(Kweet kweet)
        {
            await _kweets.InsertOneAsync(kweet);
            return kweet;
        }

        public async Task Update(Guid id, Kweet kweetIn) =>
            await _kweets.ReplaceOneAsync(kweet => kweet.Id == id, kweetIn);

        public async void Remove(Kweet kweetIn) =>
            await _kweets.DeleteOneAsync(kweet => kweet.Id == kweetIn.Id);

        public async Task Remove(Guid id) =>
            await _kweets.DeleteOneAsync(kweet => kweet.Id == id);
    }
}