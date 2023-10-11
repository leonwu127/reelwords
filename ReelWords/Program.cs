using ReelWords.Entities;
using ReelWords.GameLogic;
using ReelWords.GameLogic.UI;
using ReelWords.Services;
using System;

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
            ReelManager reelManager = new ReelManager();
            ScoreManager scoreManager = new ScoreManager();
            IUserInteraction userInteraction = new ConsoleUserInteraction();
            DictionaryLoader dictionaryLoader = new DictionaryLoader();

            GameLogic.Game game = new GameLogic.Game(trie, reelManager, scoreManager, userInteraction, dictionaryLoader);
            game.Initialize(dictionaryFilePath, reelFilePath , scoresFilePath);
            game.Play();

        }
    }
}