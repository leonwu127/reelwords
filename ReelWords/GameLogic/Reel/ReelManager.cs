using ReelWords.GameLogic.Real;
using ReelWords.GameLogic.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic.Reel
{
    public interface ReelManager
    {
        public void LoadReels(string reelsFilePath);
        public void UpdateReels(string str);
        public void RandomizeReels();
        public void ShowReels(ScoreManager _scoreManager);
        public void AdvanceAllReels();
        public List<WordsReel> GetReels();
        public string getCurrentReelsDisplay();
    }
}
