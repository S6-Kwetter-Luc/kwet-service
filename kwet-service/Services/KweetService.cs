using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Kweet> CreateKweet(Guid kweetModelUserid, string kweetModelUsername, string kweetModelContent,
            string jwt)
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

        public async Task LikeKweet(Guid kweetId, Guid userId, string username, string jwt)
        {
            if (userId != _jwtIdClaimReaderHelper.getUserIdFromToken(jwt))
            {
                throw new NotAuthenticatedException();
            }

            var kweet = await _repository.Get(kweetId);
            if (kweet == null) throw new Exception("kweet does not exist");

            if (kweet.Likes.Any(l => l.Id == userId)) throw new Exception("You cant like this kweet again");

            kweet.Likes.Add(new User
            {
                Id = userId,
                Username = username
            });

            await _repository.Update(kweetId, kweet);
        }

        public async Task UnlikeKweet(Guid kweetId, Guid userId, string username, string jwt)
        {
            if (userId != _jwtIdClaimReaderHelper.getUserIdFromToken(jwt))
            {
                throw new NotAuthenticatedException();
            }

            var kweet = await _repository.Get(kweetId);
            if (kweet == null) throw new Exception("kweet does not exist");

            var user = kweet.Likes.Single(u => u.Id == userId);
            if (user == null) throw new Exception("You cant unlike a kweet that you havent liked");

            kweet.Likes.Remove(user);

            await _repository.Update(kweetId, kweet);
        }
    }
}