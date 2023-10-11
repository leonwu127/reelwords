using ReelWords.Entities;
using ReelWords.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Services
{
    public class DictionaryLoader
    {
        public DictionaryLoader()
        {
        }

        public void LoadWords(ITrie trie, string filePath)
        {
            if (trie == null)
            {
                throw new ArgumentNullException(nameof(trie));
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new InvalidFilePathException("File path cannot be null or empty", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist", filePath);
            }

            var words = File.ReadAllLines(filePath);
            foreach (var word in words)
            {
                trie.Insert(word);
            }
        }

    }
}
