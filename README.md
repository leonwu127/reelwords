# ReelWords

ReelWords is a word-based game where players interact with reels to form valid words and earn scores. The game utilizes a Trie data structure for efficient word searches and validations.

## Features

- **Trie Data Structure**: Efficiently search and validate words using a Trie.
- **Reel Management**: Interact with word reels to form words.
- **Scoring System**: Earn scores based on the words you form.
- **Console-based User Interaction**: Play the game directly from the console.

## Getting Started

1. Clone the repository:
`git clone https://github.com/leonwu127/reelwords.git`

2. Navigate to the project directory:
`cd reelwords`

3. Run the game:
`dotnet run --project ReelWords/ReelWords.csproj`

## Game Flow

For a detailed game flow, check out [GameFlow.txt](https://github.com/leonwu127/reelwords/blob/master/ReelWords/GameFlow.txt).

## Resources

- Word List: [american-english-large.txt](https://github.com/leonwu127/reelwords/blob/master/ReelWords/Resources/american-english-large.txt)
- Reels: [reels.txt](https://github.com/leonwu127/reelwords/blob/master/ReelWords/Resources/reels.txt)
- Scores: [scores.txt](https://github.com/leonwu127/reelwords/blob/master/ReelWords/Resources/scores.txt)

## Testing

Unit tests are available for the game logic and Trie data structure. To run the tests, navigate to the project directory and execute:
`dotnet test`

## Implementation Preference
**Handling Various Word Types in "american-english-large.txt": **
The file contains different word types like names (e.g., "Anna"), possessives (e.g., "Anna's"), abbreviations, and word variations (e.g., "é"). 
Here's how I handle them:
a. Ignoring Words with Upper Case and Special Characters: This approach will exclude names, possessives, abbreviations, and words with special characters from being inserted into the Trie. Rationale: Names and abbreviations are usually not considered as restricted words, and since the reel only has a limited vocabulary, there's little value in matching words with special characters.
b. Limiting Word Length: Only words with six or fewer characters will be considered, aligning with the fact that there are only six reels. 
c. Normalizing Word Variations: Variations in words will be normalized to ensure accurate matching. 

**Resolving Ambiguities in User Input: **
For instance, if the program displays "a a b n n d" and the user enters "and", there's a potential ambiguity in determining which letters on the reel should match the entered word.  
My implementation:
a. Match the Letters from Left to Right: This approach will match the first occurrence of each letter from the left. 
