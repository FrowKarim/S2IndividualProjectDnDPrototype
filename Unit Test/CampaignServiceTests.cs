using Xunit;
using Moq;
using LogicLayer.Services;
using LogicLayer.Entities;
using LogicLayer.Interfaces;

namespace LogicLayer.Tests.Services
{
    public class CampaignServiceTests
    {
        private readonly Mock<ICampaignRepo> _mockCampaignRepo;
        private readonly CampaignService _campaignService;

        public CampaignServiceTests()
        {
            _mockCampaignRepo = new Mock<ICampaignRepo>();
            _campaignService = new CampaignService(_mockCampaignRepo.Object);
        }

        #region GetCampaign Tests
        [Fact]
        public void GetCampaign_WithValidCampaignID_ReturnsCampaign()
        {
            // Arrange
            var campaignId = 1;
            var expectedCampaign = new Campaign
            {
                Id = 1,
                Name = "The Quest for the Ring",
                Owner = "Gandalf",
                Description = "An epic adventure"
            };
            _mockCampaignRepo.Setup(repo => repo.GetCampaign(campaignId))
                .Returns(expectedCampaign);

            // Act
            var result = _campaignService.GetCampaign(campaignId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCampaign.Id, result.Id);
            Assert.Equal(expectedCampaign.Name, result.Name);
            _mockCampaignRepo.Verify(repo => repo.GetCampaign(campaignId), Times.Once);
        }

        [Fact]
        public void GetCampaign_WithInvalidCampaignID_ReturnsNull()
        {
            // Arrange
            var campaignId = 999;
            _mockCampaignRepo.Setup(repo => repo.GetCampaign(campaignId))
                .Returns((Campaign)null);

            // Act
            var result = _campaignService.GetCampaign(campaignId);

            // Assert
            Assert.Null(result);
            _mockCampaignRepo.Verify(repo => repo.GetCampaign(campaignId), Times.Once);
        }

        [Fact]
        public void GetCampaign_WithZeroCampaignID_CallsRepository()
        {
            // Arrange
            var campaignId = 0;
            _mockCampaignRepo.Setup(repo => repo.GetCampaign(campaignId))
                .Returns((Campaign)null);

            // Act
            var result = _campaignService.GetCampaign(campaignId);

            // Assert
            Assert.Null(result);
        }
        #endregion

        #region CreateCampaign Tests
        [Fact]
        public void CreateCampaign_WithValidCampaign_CallsAddCampaign()
        {
            // Arrange
            var campaign = new Campaign
            {
                Name = "Dragon's Lair",
                Owner = "DM_Master",
                Description = "Face the ancient dragon"
            };
            _mockCampaignRepo.Setup(repo => repo.AddCampaign(campaign))
                .Returns(campaign);

            // Act
            _campaignService.CreateCampaign(campaign);

            // Assert
            _mockCampaignRepo.Verify(repo => repo.AddCampaign(campaign), Times.Once);
        }

        [Fact]
        public void CreateCampaign_WithNullCampaign_CallsRepository()
        {
            // Arrange
            Campaign campaign = null;

            // Act
            _campaignService.CreateCampaign(campaign);

            // Assert
            _mockCampaignRepo.Verify(repo => repo.AddCampaign(null), Times.Once);
        }

        [Fact]
        public void CreateCampaign_WithMinimalData_CallsAddCampaign()
        {
            // Arrange
            var campaign = new Campaign { Name = "New Adventure" };

            // Act
            _campaignService.CreateCampaign(campaign);

            // Assert
            _mockCampaignRepo.Verify(repo => repo.AddCampaign(campaign), Times.Once);
        }
        #endregion

        #region DeleteCampaign Tests
        [Fact]
        public void DeleteCampaign_WithValidCampaign_ReturnsDeletedCampaign()
        {
            // Arrange
            var campaign = new Campaign
            {
                Id = 1,
                Name = "Forgotten Campaign"
            };
            _mockCampaignRepo.Setup(repo => repo.DeleteCampaign(campaign))
                .Returns(campaign);

            // Act
            var result = _campaignService.DeleteCampaign(campaign);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(campaign.Id, result.Id);
            _mockCampaignRepo.Verify(repo => repo.DeleteCampaign(campaign), Times.Once);
        }

        [Fact]
        public void DeleteCampaign_CallsRepositoryDeleteMethod()
        {
            // Arrange
            var campaign = new Campaign { Id = 3, Name = "Test Campaign" };

            // Act
            _campaignService.DeleteCampaign(campaign);

            // Assert
            _mockCampaignRepo.Verify(repo => repo.DeleteCampaign(campaign), Times.Once);
        }

        [Fact]
        public void DeleteCampaign_WithNullCampaign_CallsRepository()
        {
            // Arrange
            Campaign campaign = null;

            // Act
            _campaignService.DeleteCampaign(campaign);

            // Assert
            _mockCampaignRepo.Verify(repo => repo.DeleteCampaign(null), Times.Once);
        }
        #endregion
    }
}