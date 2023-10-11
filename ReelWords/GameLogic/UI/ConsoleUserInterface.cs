using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic.UI
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public string GetPlayerInput()
        {
            Console.Write("Enter a word: ");
            return Console.ReadLine();
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
