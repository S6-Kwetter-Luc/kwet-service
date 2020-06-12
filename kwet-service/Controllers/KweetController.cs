using System;
using System.Threading.Tasks;
using kwet_service.Models;
using kwet_service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kwet_service.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class KweetController : ControllerBase
    {
        private IKweetService _kweetService;

        public KweetController(IKweetService kweetService)
        {
            _kweetService = kweetService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateKweet([FromBody] KweetModel kweetModel)
        {
            try
            {
                await _kweetService.CreateKweet(kweetModel.UserId, kweetModel.Username, kweetModel.Content);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid userId)
        {
            try
            {
                return Ok(await _kweetService.GetByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}