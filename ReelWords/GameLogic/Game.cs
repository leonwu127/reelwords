using ReelWords.Entities;
using ReelWords.GameLogic.Reel;
using ReelWords.GameLogic.Score;
using ReelWords.GameLogic.UI;
using ReelWords.Services;
using ReelWords.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic
{
    public class Game
    {
        private readonly ITrie _trie;
        private readonly ReelManager _reelManager;
        private readonly ScoreManager _scoreManager;
        private readonly IUserInteraction _userInteraction;
        private readonly DictionaryLoader _dictionaryLoader;

        public Game(
            ITrie trie,
            ReelManager reelManager,
            ScoreManager scoreManager,
            IUserInteraction userInteraction,
            DictionaryLoader dictionaryLoader)
        {
            _trie = trie;
            _reelManager = reelManager;
            _scoreManager = scoreManager;
            _userInteraction = userInteraction;
            _dictionaryLoader = dictionaryLoader;
        }

        public void Initialize(string dictionaryFilePath, string reelsFilePath, string scoresFilePath)
        {
            _dictionaryLoader.LoadWords(_trie, dictionaryFilePath);
            _reelManager.LoadReels(reelsFilePath);
            _scoreManager.LoadScores(scoresFilePath);
        }

        public void Play()
        {
            bool isGameOver = false;
            while (!isGameOver)
            {
                _reelManager.ShowReels(_scoreManager);

                string inputWord = _userInteraction.GetPlayerInput();
                if (inputWord.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    isGameOver = true;
                    _userInteraction.DisplayMessage($"Your final score is: {_scoreManager.GetScore()}");
                    _userInteraction.DisplayMessage("Thanks for playing!");
                    break;
                }

                if (!WordValidator.IsValidWord(inputWord))
                {
                    _userInteraction.DisplayMessage("Invalid input. Try again.");
                    continue;
                }

                char[] currentLetters = _reelManager.getCurrentReelsDisplay().ToCharArray();

                if (WordValidator.IsWordFormable(currentLetters, inputWord) && _trie.Search(inputWord))
                {
                    _userInteraction.DisplayMessage("Word is formable! Selected words will be rolled to the next position.");
                    _scoreManager.UpdateScore(inputWord);
                }
                else
                {
                    _userInteraction.DisplayMessage("Invalid word! Word is not formable! Try again.");
                    string rollReels = _userInteraction.Prompt("Do you want to roll the reels? (y or [Press any key to try again])");
                    if (rollReels.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        _userInteraction.DisplayMessage("All words will be rolled to the next position.");
                        _reelManager.AdvanceAllReels();
                    }
                    continue;
                }
                _reelManager.UpdateReels(inputWord);
                _userInteraction.DisplayMessage($"Your current score is: {_scoreManager.GetScore()}");
            }

        }
    }

}
