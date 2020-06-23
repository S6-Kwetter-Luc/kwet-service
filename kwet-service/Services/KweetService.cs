using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kwet_service.Entities;
using kwet_service.Exceptions;
using kwet_service.Helpers;
using kwet_service.Repositories;

namespace kwet_service.Services
{
    public class KweetService : IKweetService
    {
        private readonly IKweetRepository _repository;
        private readonly IJwtIdClaimReaderHelper _jwtIdClaimReaderHelper;

        public KweetService(IKweetRepository repository, IJwtIdClaimReaderHelper jwtIdClaimReaderHelper)
        {
            _repository = repository;
            _jwtIdClaimReaderHelper = jwtIdClaimReaderHelper;
        }

        public Task<Kweet> CreateKweet(Guid kweetModelUserid, string kweetModelUsername, string kweetModelContent, string jwt)
        {
            if (kweetModelUserid != _jwtIdClaimReaderHelper.getUserIdFromToken(jwt))
            {
                throw new NotAuthenticatedException();
            }

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

        public async Task<List<Kweet>> Get()
        {
            return await _repository.Get();
        }
    }
}