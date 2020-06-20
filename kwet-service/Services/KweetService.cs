using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kwet_service.Entities;
using kwet_service.Repositories;

namespace kwet_service.Services
{
    public class KweetService : IKweetService
    {
        private IKweetRepository _repository;

        public KweetService(IKweetRepository repository)
        {
            _repository = repository;
        }

        public Task<Kweet> CreateKweet(Guid kweetModelUserid, string kweetModelUsername, string kweetModelContent)
        {
            var kweet = new Kweet
            {
                Content = kweetModelContent,
                DateTime = DateTime.Now,
                Writer = new User
                {
                    Id = kweetModelUserid,
                    Username = kweetModelUsername
                },
                Likes = new List<User>()
            };
            return _repository.Create(kweet);
        }

        public async Task<List<Kweet>> GetByUserId(Guid userId)
        {
            return await _repository.GetByUserId(userId);
        }
    }
}