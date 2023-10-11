using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic.Score
{
    public interface ScoreManager
    {
        public void LoadScores(string scoresFilePath);
        public void UpdateScore(string word);
        public int GetScoreForLetter(char letter);
        public int GetScore();
        public void ResetScore();
    }
}
