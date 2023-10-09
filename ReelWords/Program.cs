using System;

namespace ReelWords
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string dictionaryFilePath = @"..\..\..\Resources\american-english-large.txt";
            string reelFilePath = @"..\..\..\Resources\reels.txt";  // Assuming the file is named reels.txt
            string scoresFilePath = @"..\..\..\Resources\scores.txt";  // Assuming the file is named scores.txt


            GameLogic.Game game = new GameLogic.Game();
            game.Initialize(dictionaryFilePath, reelFilePath , scoresFilePath);
            game.Play();

        }
    }
}