﻿using ReelWords.Entities;
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
        private readonly Trie _trie;
        private readonly ReelManager _reelManager;
        private readonly ScoreManager _scoreManager;
        private readonly IUserInteraction _userInteraction;
        private readonly DictionaryLoader _dictionaryLoader;

        public Game(
            Trie trie,
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

                string inputWord = GetPlayerInput();
                if (inputWord.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    isGameOver = true;
                    Console.WriteLine("Thanks for playing!");
                    break;
                }

                if (!WordValidator.IsValidWord(inputWord))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (_reelManager.IsWordFormable(inputWord) && _trie.Search(inputWord))
                {
                    Console.WriteLine("Word is formable!");
                    _scoreManager.UpdateScore(inputWord);
                }
                else
                {
                    Console.WriteLine("Word is not formable! Try again.");
                    Console.WriteLine("Do you want to roll the reels? (y/n)");
                    string rollReels = Console.ReadLine();
                    if (rollReels.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        _reelManager.AdvanceAllReels();
                    } else
                    {
                        Console.WriteLine("[Press any key to try again]");
                        Console.ReadKey(true);
                        Console.WriteLine();
                    }
                    continue;
                }

                _reelManager.UpdateReels(inputWord);

                Console.WriteLine($"Your current score is: {_scoreManager.Score}");

            }

        }

        private string GetPlayerInput()
        {
            Console.Write("Enter a word: ");
            return Console.ReadLine();
        }
    }

}
