using System;
using Moq;
using ReelWords.Entities;
using ReelWords.GameLogic;
using ReelWords.GameLogic.UI;
using ReelWords.Services;
using ReelWords.Utility;
using Xunit;

namespace ReelWords.Tests
{
    public class GameTests
    {
        private Mock<Trie> _mockTrie;
        private Mock<ReelManager> _mockReelManager;
        private Mock<ScoreManager> _mockScoreManager;
        private Mock<IUserInteraction> _mockUserInteraction;
        private Mock<DictionaryLoader> _mockDictionaryLoader;

        public GameTests()
        {
            _mockTrie = new Mock<Trie>();
            _mockReelManager = new Mock<ReelManager>();
            _mockScoreManager = new Mock<ScoreManager>();
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockDictionaryLoader = new Mock<DictionaryLoader>();
        }

        [Fact]
        public void Play_ShouldExitOnExitInput()
        {
            // Arrange
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.Setup(ui => ui.GetPlayerInput()).Returns("exit");

            // Act
            game.Play();

            // Assert
            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Thanks for playing!"), Times.Once());
        }

        [Fact]
        public void Play_ShouldHandleInvalidInput()
        {
            // Arrange
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("invalid")
                .Returns("exit");

            // Act
            game.Play();

            // Assert
            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Invalid input. Try again."), Times.Once());
        }

        // Additional tests covering other game flow scenarios can follow...
    }
}
