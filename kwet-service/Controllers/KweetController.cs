using kwet_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace kwet_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KweetController : ControllerBase
    {
        private IKweetService _kweetService;

        public KweetController(IKweetService kweetService)
        {
            _kweetService = kweetService;
        }

    }
}