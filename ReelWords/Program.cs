using ReelWords.Entities;
using ReelWords.GameLogic;
using ReelWords.GameLogic.Reel;
using ReelWords.GameLogic.UI;
using ReelWords.Services;

namespace ReelWords
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string dictionaryFilePath = @"..\..\..\Resources\american-english-large.txt";
            string reelFilePath = @"..\..\..\Resources\reels.txt";
            string scoresFilePath = @"..\..\..\Resources\scores.txt";

            Trie trie = new Trie();
            ReelManager reelManager = new WordsReelManager();
            RWScoreManager scoreManager = new RWScoreManager();
            IUserInteraction userInteraction = new ConsoleUserInteraction();
            DictionaryLoader dictionaryLoader = new DictionaryLoader();

            Game game = new Game(trie, reelManager, scoreManager, userInteraction, dictionaryLoader);
            game.Initialize(dictionaryFilePath, reelFilePath , scoresFilePath);
            game.Play();

        }
    }
}