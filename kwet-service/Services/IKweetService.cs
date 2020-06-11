using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kwet_service.Entities;

namespace kwet_service.Services
{
    public interface IKweetService
    {
        Task<Kweet> CreateKweet(Guid kweetModelUserid, string kweetModelUsername, string kweetModelContent);
        Task<List<Kweet>> GetByUserId(Guid userId);
    }
}