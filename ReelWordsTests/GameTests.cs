using System;
using System.Collections.Generic;
using Moq;
using ReelWords.Entities;
using ReelWords.GameLogic;
using ReelWords.GameLogic.Real;
using ReelWords.GameLogic.Reel;
using ReelWords.GameLogic.Score;
using ReelWords.GameLogic.UI;
using ReelWords.Services;
using ReelWords.Utility;
using Xunit;

namespace ReelWords.Tests
{
    public class GameTests
    {
        private Mock<ITrie> _mockTrie;
        private Mock<ReelManager> _mockReelManager;
        private Mock<ScoreManager> _mockScoreManager;
        private Mock<IUserInteraction> _mockUserInteraction;
        private Mock<DictionaryLoader> _mockDictionaryLoader;
        

        public GameTests()
        {
            _mockTrie = new Mock<ITrie>();
            _mockReelManager = new Mock<ReelManager>();
            _mockScoreManager = new Mock<ScoreManager>();
            _mockUserInteraction = new Mock<IUserInteraction>();
            _mockDictionaryLoader = new Mock<DictionaryLoader>();
        }

        [Fact]
        public void Play_ShouldExitOnExitInput()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.Setup(ui => ui.GetPlayerInput()).Returns("exit");

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Thanks for playing!"), Times.Once());
        }

        [Fact]
        public void Play_ShouldHandleInvalidInput()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("invalid")
                .Returns("exit");

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Invalid input. Try again."), Times.Once());
        }


        [Fact]
        public void Play_ShouldNotifyOnInvalidWordThatHaveMoreThan6Words()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("invalidword")
                .Returns("exit");

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Invalid input. Try again."), Times.Once());
        }

        [Fact]
        public void Play_ShouldUpdateScoreOnValidWord()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);
            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("valid")
                .Returns("exit");
            _mockReelManager.Setup(rm => rm.getCurrentReelsDisplay()).Returns("vdalid");  
            _mockTrie.Setup(t => t.Search(It.IsAny<string>())).Returns(true);
            _mockScoreManager.Setup(sm => sm.UpdateScore(It.IsAny<string>()));
            _mockScoreManager.Setup(sm => sm.GetScore()).Returns(1);

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Your current score is: 1"), Times.Once());

        }

        [Fact]
        public void InputWordInWrongOrder_Play_ShouldUpdateScoreOnValidWord()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);
            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("lidva")
                .Returns("exit");
            _mockReelManager.Setup(rm => rm.getCurrentReelsDisplay()).Returns("vdalid");
            _mockTrie.Setup(t => t.Search(It.IsAny<string>())).Returns(true);
            _mockScoreManager.Setup(sm => sm.UpdateScore(It.IsAny<string>()));
            _mockScoreManager.Setup(sm => sm.GetScore()).Returns(1);


            game.Play();

            _mockReelManager.Verify(rm => rm.UpdateReels(It.IsAny<string>()), Times.Once());
            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Your current score is: 1"), Times.Once());

        }


        [Fact]
        public void InputWordExistInReelsButNotFormable_AskForReRoll_ShouldRollReelsOnUserConfirmation()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("ordy")
                .Returns("exit");
            _mockReelManager.Setup(rm => rm.getCurrentReelsDisplay()).Returns("oyrlid");
            _mockUserInteraction.Setup(ui => ui.Prompt(It.IsAny<string>())).Returns("y");

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Invalid word! Word is not formable! Try again."), Times.Once());
            _mockReelManager.Verify(rm => rm.AdvanceAllReels(), Times.Once());
        }

        [Fact]
        public void InputWordExistInReelsButNotFormable_NoReroll_ShouldNotRollReels()
        {
            var game = new Game(
                _mockTrie.Object,
                _mockReelManager.Object,
                _mockScoreManager.Object,
                _mockUserInteraction.Object,
                _mockDictionaryLoader.Object);

            _mockUserInteraction.SetupSequence(ui => ui.GetPlayerInput())
                .Returns("ordy")
                .Returns("exit");
            _mockReelManager.Setup(rm => rm.getCurrentReelsDisplay()).Returns("oyrlid");
            _mockUserInteraction.Setup(ui => ui.Prompt(It.IsAny<string>())).Returns(".");

            game.Play();

            _mockUserInteraction.Verify(ui => ui.DisplayMessage("Invalid word! Word is not formable! Try again."), Times.Once());
            _mockReelManager.Verify(rm => rm.AdvanceAllReels(), Times.Never);
        }

    }
}
