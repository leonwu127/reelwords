using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Entities
{
    internal class TrieNode
    {
        public TrieNode[] Children { get; set; } = new TrieNode[26];
        public bool IsEndOfWord { get; set; }
    }
}
