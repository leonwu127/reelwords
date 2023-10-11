using ReelWords.Entities;
using ReelWords.Exceptions;
using Xunit;

namespace ReelWordsTests
{
    public class TrieTests
    {
        private const string TEST_WORD = "rell";

        [Fact]
        public void TrieInsertTest()
        {
            Trie trie = new Trie();
            trie.Insert(TEST_WORD);
            Assert.True(trie.Search(TEST_WORD));
        }

        [Fact]
        public void TrieDeleteTest()
        {
            Trie trie = new Trie();
            trie.Insert(TEST_WORD);
            Assert.True(trie.Search(TEST_WORD));
            trie.Delete(TEST_WORD);
            Assert.False(trie.Search(TEST_WORD));
        }

        [Fact]
        public void TrieInsert_EmptyString_ShouldNotThrowAnything()
        {
            Trie trie = new Trie();
            trie.Insert(string.Empty);
        }

        [Fact]
        public void TrieSearch_EmptyString_ReturnsFalse()
        {
            Trie trie = new Trie();
            Assert.False(trie.Search(string.Empty));
        }

        [Fact]
        public void TrieDelete_EmptyString_ThrowsInvlidWordException()
        {
            Trie trie = new Trie();
            Assert.Throws<InvalidWordException>(() => trie.Delete(string.Empty));
        }

        [Fact]
        public void TrieInsert_NullString_ShouldNotThrowAnything()
        {
            Trie trie = new Trie();
            trie.Insert(null);
        }

        [Fact]
        public void TrieSearch_NullString_ReturnsFalse()
        {
            Trie trie = new Trie();
            Assert.False(trie.Search(null));
        }

        [Fact]
        public void TrieDelete_NullString_ThrowsInvlidWordException()
        {
            Trie trie = new Trie();
            Assert.Throws<InvalidWordException>(() => trie.Delete(null));
            // Asserting that no exception is thrown
        }

        [Fact]
        public void TrieInsert_SameWordTwice_ShouldNotThrowException()
        {
            Trie trie = new Trie();
            trie.Insert(TEST_WORD);
            trie.Insert(TEST_WORD);
            // Asserting that no exception is thrown
        }

        [Fact]
        public void TrieDelete_WordNotPresent_ShouldNotThrowException()
        {
            Trie trie = new Trie();
            trie.Delete(TEST_WORD);
            // Asserting that no exception is thrown
        }

    }
}