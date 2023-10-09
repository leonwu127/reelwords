﻿using ReelWords.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic
{
    public class ReelManager
    {
        private readonly List<Reel> _reels;

        public ReelManager()
        {
            _reels = new List<Reel>();
        }

        public void LoadReels(string reelsFilePath)
        {
            if (string.IsNullOrEmpty(reelsFilePath))
            {
                throw new InvalidFilePathException("Reels file path cannot be null or empty", nameof(reelsFilePath));
            }

            if (!File.Exists(reelsFilePath))
            {
                throw new FileNotFoundException("The specified reels file does not exist", reelsFilePath);
            }

            var reelLines = File.ReadAllLines(reelsFilePath);
            foreach (var line in reelLines)
            {
                var l = line.Replace(" ", "");  // Remove any spaces from the line
                var reel = new Reel(l);  // Assuming a Reel constructor that takes a string of letters.
                _reels.Add(reel);
            }

            // Optionally, randomize the initial positions of the reels.
            RandomizeReels();
        }

        public void UpdateReels(string word)
        {
            // TODO: Implement reel update logic based on the word that was played.
            if (string.IsNullOrEmpty(word)) throw new InvalidWordException();

            var usedReels = new HashSet<int>();  // Keeps track of reels already used for a letter

            foreach (char letter in word)
            {
                for (int i = 0; i < _reels.Count; i++)
                {
                    if (usedReels.Contains(i)) continue;  // Skip reels that have already been used

                    if (_reels[i].CurrentLetter == letter)
                    {
                        _reels[i].AdvancePosition();  // Advance the reel by one position
                        usedReels.Add(i);  // Mark this reel as used
                        break;  // Break out of the loop as the letter was found in this reel
                    }
                }
            }
        }

        private void RandomizeReels()
        {
            var random = new Random();
            foreach (var reel in _reels)
            {
                reel.RandomizePosition(random);  // Assuming a RandomizePosition method on the Reel class.
            }
        }

        public void ShowReels(ScoreManager _scoreManager)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < _reels.Count; i++)
            {
                var letter = _reels[i].CurrentLetter;
                var score = _scoreManager.getScore(letter);
                output.AppendFormat("{0}[{1}] ", letter, score);
            }

            // Trim the trailing space if there is one, and then write the output to the console
            Console.WriteLine(output.ToString().TrimEnd());
        }

        internal bool IsWordFormable(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;

            var usedReels = new HashSet<int>();  // Keeps track of reels already used for a letter

            foreach (char letter in word)
            {
                bool letterFound = false;

                for (int i = 0; i < _reels.Count; i++)
                {
                    if (usedReels.Contains(i)) continue;  // Skip reels that have already been used

                    if (_reels[i].CurrentLetter == letter)
                    {
                        usedReels.Add(i);  // Mark this reel as used
                        letterFound = true;
                        break;  // Break out of the loop as the letter was found in this reel
                    }
                }

                if (!letterFound)
                {
                    return false;  // The letter was not found in any of the remaining reels
                }
            }

            return true;  // All letters were found in the reels
        }

        internal void AdvanceAllReels()
        {
            foreach (var reel in _reels)
            {
                reel.AdvancePosition();
            }
        }
    }

}
