using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.GameLogic
{
    public class Reel
    {
        private readonly List<char> _letters;
        private int _currentPosition;

        public Reel(string letters)
        {
            _letters = new List<char>(letters);
            _currentPosition = 0;
        }

        public char CurrentLetter => _letters[_currentPosition];

        public void RandomizePosition(Random random)
        {
            _currentPosition = random.Next(_letters.Count);
        }

        internal void AdvancePosition()
        {
            _currentPosition = (_currentPosition + 1) % _letters.Count;
        }

        // TODO: Other methods for manipulating and querying the state of the reel.
    }
}
