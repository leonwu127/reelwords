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

