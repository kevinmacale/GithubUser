using GitHubApi.Dtos;
using GitHubApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GithubApi.Test
{
    public class GithubUserServiceTest
    {
        private readonly GithubUserProfileTransport _githubUserProfileResponse = new GithubUserProfileTransport()
        {
            AvatarUrl = "TestAvatar",
            Company = "TestCompany",
            Id = 1,
            Name = "TestName",
            NumberOfFollowers = 1,
            NumberOfPublicRepositories = 1,
        };

        private readonly string _userAgent = "test-user";
        private readonly Mock<ILogger<GithubUserService>> _mockLogger;
        private readonly Mock<IGithubUserApiClient> _mockGithubUserApiClient;
        public GithubUserServiceTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            _mockLogger = mockRepository.Create<ILogger<GithubUserService>>();
            _mockGithubUserApiClient = mockRepository.Create<IGithubUserApiClient>();
        }

        [Fact]
        public async Task GetUser_ReturnsSuccess()
        {
            SetupEnvironmentContext(new List<GithubUserProfileTransport>()
            {
                _githubUserProfileResponse
            });

            var githubUserService = new GithubUserService(_mockLogger.Object, _mockGithubUserApiClient.Object);

            var getGithubUsersResponse = await githubUserService.GetUsers(_userAgent, CancellationToken.None);

            _mockGithubUserApiClient.Verify(x => x.GetUsers(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());

            Assert.NotNull(getGithubUsersResponse);
            Assert.NotEmpty(getGithubUsersResponse.GithubUserProfileTransports);
            Assert.Equal(getGithubUsersResponse.GithubUserProfileTransports.FirstOrDefault().Id, _githubUserProfileResponse.Id);
        }   
        
        [Fact]
        public async Task GetUser_ReturnsFailure()
        {
            SetupEnvironmentContext(new List<GithubUserProfileTransport>());

            var githubUserService = new GithubUserService(_mockLogger.Object, _mockGithubUserApiClient.Object);

            var getGithubUsersResponse = await githubUserService.GetUsers(_userAgent, CancellationToken.None);

            _mockGithubUserApiClient.Verify(x => x.GetUsers(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());

            Assert.Empty(getGithubUsersResponse.GithubUserProfileTransports);
            Assert.NotEqual(getGithubUsersResponse.GithubUserProfileTransports.FirstOrDefault()?.Id, _githubUserProfileResponse.Id);
        }

        private void SetupEnvironmentContext(List<GithubUserProfileTransport> githubUserProfileTransports)
        {
            _mockGithubUserApiClient.Setup(x => x.GetUsers(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(githubUserProfileTransports);
        }      
    }
}