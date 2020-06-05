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
    }
}