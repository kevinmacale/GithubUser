using GitHubApi.Dtos;
using GitHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GitHubApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubUserController : ControllerBase
    {
        private readonly ILogger<GithubUserController> _logger;
        private readonly IGithubUserService _githubUserService;

        public GithubUserController(ILogger<GithubUserController> logger,
            IGithubUserService githubUserService)
        {
            _logger = logger;
            _githubUserService = githubUserService;
        }

        [HttpGet]
        public async Task<ActionResult<GetGithubUsersResponse>> GetUsers(CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("Get users was called");

            try
            {
                return await _githubUserService.GetUsers(FetchUserAgent(), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Error in getting github users", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string FetchUserAgent()
        {
            try
            {
                return HttpContext.Request.Headers["User-Agent"].ToString();
            }
            catch (Exception ex)
            {
                _logger.LogDebug("FetchUserAgent failed - with error message {@error}", ex.Message);
                return string.Empty;
            }
        }
    }
}
