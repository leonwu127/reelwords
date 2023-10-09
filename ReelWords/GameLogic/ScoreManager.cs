using ReelWords.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReelWords.GameLogic
{
    public class ScoreManager
    {
        private int _score;
        private Dictionary<char, int> _scoreTable;

        public ScoreManager()
        {
            _score = 0;
            _scoreTable = new Dictionary<char, int>();
        }

        public int Score => _score;

        public void LoadScores(string scoresFilePath)
        {
            if (string.IsNullOrEmpty(scoresFilePath))
            {
                throw new InvalidFilePathException("Scores file path cannot be null or empty", nameof(scoresFilePath));
            }

            if (!File.Exists(scoresFilePath))
            {
                throw new FileNotFoundException("The specified scores file does not exist", scoresFilePath);
            }

            var scoreLines = File.ReadAllLines(scoresFilePath);
            foreach (var line in scoreLines)
            {
                var parts = line.Split(' ');
                if (parts.Length != 2 || !int.TryParse(parts[1], out var points))
                {
                    throw new FormatException("Invalid score file format");
                }

                var letter = parts[0][0];
                _scoreTable[letter] = points;
            }
        }

        public void UpdateScore(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new InvalidWordException();
            }

            foreach (char letter in word.ToLower())
            {
                if (_scoreTable.TryGetValue(letter, out var points))
                {
                    _score += points;
                }
                else
                {
                    throw new InvalidWordException($"Score not found for letter '{letter}'");
                }
            }
        }

        public int getScore(char letter)
        {
            if (_scoreTable.TryGetValue(letter, out var points))
            {
                return points;
            }
            else
            {
                throw new InvalidWordException($"Score not found for letter '{letter}'");
            }
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
