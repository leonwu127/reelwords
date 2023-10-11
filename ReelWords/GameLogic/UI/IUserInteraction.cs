using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic.UI
{
    public interface IUserInteraction
    {
        string GetPlayerInput();
        void DisplayMessage(string message);
        string Prompt(string message);
    }
}
