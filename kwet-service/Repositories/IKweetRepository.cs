using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kwet_service.Entities;

namespace kwet_service.Repositories
{
    public interface IKweetRepository
    {
        Task<List<Kweet>> Get();
        // Task<Kweet> GetByEmail(string email);
        // Task<Kweet> GetByKweetname(string kweetname);
        Task<Kweet> GetByGuid(Guid id);
        Task<Kweet> Get(Guid id);
        Task<Kweet> Create(Kweet kweet);
        Task Update(Guid id, Kweet kweetIn);
        void Remove(Kweet kweetIn);
        Task Remove(Guid id);
        Task<List<Kweet>> GetByUserId(Guid userId);
        void RemoveKweetsFromUser(Guid userId);
        void UpdateKweetsByUser(Guid userId, string newUsername);
    }
}