using Xunit;
using Moq;
using LogicLayer.Services;
using LogicLayer.Entities;
using LogicLayer.Interfaces;
using System.Collections.Generic;

namespace LogicLayer.Tests.Services
{
    public class CharacterServiceTests
    {
        private readonly Mock<ICharacterRepo> _mockCharacterRepo;
        private readonly CharacterService _characterService;

        public CharacterServiceTests()
        {
            _mockCharacterRepo = new Mock<ICharacterRepo>();
            _characterService = new CharacterService(_mockCharacterRepo.Object);
        }

        #region GetCharacter Tests
        [Fact]
        public void GetCharacter_WithValidCharacterID_ReturnsCharacter()
        {
         

            // Arrange
            var characterId = "1";
            var expectedCharacter = new Character
            {
                Id = 1,
                Name = "Aragorn",
                UserId = 1,
                CampaignId = 1,
                maxHealth = 100,
                currentHealth = 100
            };
            _mockCharacterRepo.Setup(repo => repo.GetCharacter(characterId))
                .Returns(expectedCharacter);

            // Act
            var result = _characterService.GetCharacter(characterId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCharacter.Id, result.Id);
            Assert.Equal(expectedCharacter.Name, result.Name);
            _mockCharacterRepo.Verify(repo => repo.GetCharacter(characterId), Times.Once);
        }

        [Fact]
        public void GetCharacter_WithInvalidCharacterID_ReturnsNull()
        {
            // Arrange
            var characterId = "999";
            _mockCharacterRepo.Setup(repo => repo.GetCharacter(characterId))
                .Returns((Character)null);

            // Act
            var result = _characterService.GetCharacter(characterId);

            // Assert
            Assert.Null(result);
            _mockCharacterRepo.Verify(repo => repo.GetCharacter(characterId), Times.Once);
        }

        [Fact]
        public void GetCharacter_WithEmptyCharacterID_CallsRepository()
        {
            // Arrange
            var characterId = "";
            _mockCharacterRepo.Setup(repo => repo.GetCharacter(characterId))
                .Returns((Character)null);

            // Act
            var result = _characterService.GetCharacter(characterId);

            // Assert
            Assert.Null(result);
            _mockCharacterRepo.Verify(repo => repo.GetCharacter(characterId), Times.Once);
        }
        #endregion

        #region CreateCharacter Tests
        [Fact]
        public void CreateCharacter_WithValidCharacter_CallsAddCharacter()
        {
            // Arrange
            var character = new Character
            {
                Name = "Legolas",
                UserId = 2,
                CampaignId = 1,
                maxHealth = 80,
                currentHealth = 80
            };
            _mockCharacterRepo.Setup(repo => repo.AddCharacter(character))
                .Returns(character);

            // Act
            _characterService.CreateCharacter(character);

            // Assert
            _mockCharacterRepo.Verify(repo => repo.AddCharacter(character), Times.Once);
        }

        [Fact]
        public void CreateCharacter_WithNullCharacter_CallsRepository()
        {
            // Arrange
            Character character = null;

            // Act
            _characterService.CreateCharacter(character);

            // Assert
            _mockCharacterRepo.Verify(repo => repo.AddCharacter(null), Times.Once);
        }

        [Fact]
        public void CreateCharacter_WithMinimalCharacterData_CallsAddCharacter()
        {
            // Arrange
            var character = new Character { Name = "Gimli" };

            // Act
            _characterService.CreateCharacter(character);

            // Assert
            _mockCharacterRepo.Verify(repo => repo.AddCharacter(character), Times.Once);
        }
        #endregion

        #region UpdateCharacter Tests
        [Fact]
        public void UpdateCharacter_WithValidCharacter_ReturnsUpdatedCharacter()
        {
            // Arrange
            var character = new Character
            {
                Id = 1,
                Name = "Gandalf",
                UserId = 3,
                CampaignId = 1,
                currentHealth = 50
            };
            _mockCharacterRepo.Setup(repo => repo.UpdateCharacter(character))
                .Returns(character);

            // Act
            var result = _characterService.UpdateCharacter(character);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(character.Id, result.Id);
            Assert.Equal(character.currentHealth, result.currentHealth);
            _mockCharacterRepo.Verify(repo => repo.UpdateCharacter(character), Times.Once);
        }

        [Fact]
        public void UpdateCharacter_WithHealthStats_UpdatesCurrentHealth()
        {
            // Arrange
            var character = new Character
            {
                Id = 2,
                maxHealth = 100,
                currentHealth = 75,
                maxStrength = 50,
                currentStrength = 40
            };
            _mockCharacterRepo.Setup(repo => repo.UpdateCharacter(character))
                .Returns(character);

            // Act
            var result = _characterService.UpdateCharacter(character);

            // Assert
            Assert.Equal(75, result.currentHealth);
            Assert.Equal(40, result.currentStrength);
        }

        [Fact]
        public void UpdateCharacter_WithNullCharacter_CallsRepository()
        {
            // Arrange
            Character character = null;
            _mockCharacterRepo.Setup(repo => repo.UpdateCharacter(null))
                .Returns((Character)null);

            // Act
            var result = _characterService.UpdateCharacter(character);

            // Assert
            Assert.Null(result);
        }
        #endregion

        #region DeleteCharacter Tests
        [Fact]
        public void DeleteCharacter_WithValidCharacter_ReturnsDeletedCharacter()
        {
            // Arrange
            var character = new Character
            {
                Id = 1,
                Name = "Boromir"
            };
            _mockCharacterRepo.Setup(repo => repo.DeleteCharacter(character))
                .Returns(character);

            // Act
            var result = _characterService.DeleteCharacter(character);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(character.Id, result.Id);
            _mockCharacterRepo.Verify(repo => repo.DeleteCharacter(character), Times.Once);
        }

        [Fact]
        public void DeleteCharacter_CallsRepositoryDeleteMethod()
        {
            // Arrange
            var character = new Character { Id = 5, Name = "Test Character" };

            // Act
            _characterService.DeleteCharacter(character);

            // Assert
            _mockCharacterRepo.Verify(repo => repo.DeleteCharacter(character), Times.Once);
        }
        #endregion

        #region GetCharactersByCampaign Tests
        [Fact]
        public void GetCharactersByCampaign_WithValidCampaignID_ReturnsCharacterList()
        {
            // Arrange
            var campaignId = 1;
            var expectedCharacters = new List<Character>
            {
                new Character { Id = 1, Name = "Character1", CampaignId = 1 },
                new Character { Id = 2, Name = "Character2", CampaignId = 1 }
            };
            _mockCharacterRepo.Setup(repo => repo.GetCharactersByCampaign(campaignId))
                .Returns(expectedCharacters);

            // Act
            var result = _characterService.GetCharactersByCampaign(campaignId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(expectedCharacters, result);
            _mockCharacterRepo.Verify(repo => repo.GetCharactersByCampaign(campaignId), Times.Once);
        }

        [Fact]
        public void GetCharactersByCampaign_WithInvalidCampaignID_ReturnsEmptyList()
        {
            // Arrange
            var campaignId = 999;
            var emptyList = new List<Character>();
            _mockCharacterRepo.Setup(repo => repo.GetCharactersByCampaign(campaignId))
                .Returns(emptyList);

            // Act
            var result = _characterService.GetCharactersByCampaign(campaignId);

            // Assert
            Assert.Empty(result);
            _mockCharacterRepo.Verify(repo => repo.GetCharactersByCampaign(campaignId), Times.Once);
        }

        [Fact]
        public void GetCharactersByCampaign_WithZeroCampaignID_CallsRepository()
        {
            // Arrange
            var campaignId = 0;
            _mockCharacterRepo.Setup(repo => repo.GetCharactersByCampaign(campaignId))
                .Returns(new List<Character>());

            // Act
            var result = _characterService.GetCharactersByCampaign(campaignId);

            // Assert
            Assert.NotNull(result);
            _mockCharacterRepo.Verify(repo => repo.GetCharactersByCampaign(campaignId), Times.Once);
        }
        #endregion
    }
}