using System;
using System.Linq;

namespace ReelWords.Entities
{
    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }


        public bool Search(string s)
        {
            var currentNode = root;
            foreach (var c in s)
            {
                var index = c - 'a';
                if (currentNode.Children[index] == null)
                {
                    return false;
                }
                currentNode = currentNode.Children[index];
            }
            return currentNode != null && currentNode.IsEndOfWord;
        }

        public void Insert(string word)
        {
            var currentNode = root;
            foreach (var c in word)
            {
                var index = c - 'a';
                if (currentNode.Children[index] == null)
                {
                    currentNode.Children[index] = new TrieNode();
                }
                currentNode = currentNode.Children[index];
            }   
            currentNode.IsEndOfWord = true;
        }

        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(TrieNode node, string word, int depth)
        {
            if (node == null)
            {
                return false;
            }

            if (depth == word.Length)
            {
                if (node.IsEndOfWord)
                {
                    node.IsEndOfWord = false;
                }
                return node.Children.All(child => child == null);
            }

            var index = word[depth] - 'a';
            if (Delete(node.Children[index], word, depth + 1))
            {
                node.Children[index] = null;
                return node.Children.All(child => child == null) && !node.IsEndOfWord;
            }

            return false;
        }
    }
}