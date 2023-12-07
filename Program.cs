namespace Hangman1;

class Program
{
    public const int NUMBER_OF_GUESSES = 10;
    public const char PLACEHOLDER = '_';

    static void Main(string[] args)
    {
        Console.WriteLine("Let's play Hangman! Guess the letters to complete the word!\n");

        //List for possible word
        List<String> wordList = new List<string>()
            {
                "coffee", "giraffe", "building", "mannequin", "jackhammer"
            };

        //Get random entry from List
        Random rand = new Random();
        int index = rand.Next(wordList.Count);
        string wordToGuess = wordList[index];

        //Dashes for letter space
        int wordLength = wordToGuess.Length;
        Console.WriteLine("The dashes represents each letter in the word.\n");

        //Ask user for letter guess
        char[] userGuess = new char[wordLength];
        int numberOfAttempts = 0;
        int correctLetter = 0;
        List<char> lettersAlreadyGuessed = new List<char>();
        Console.WriteLine("\nPlease enter a letter\n");


        //Replace Dash with letter
        for (int y = 0; y < wordLength; y++)
        {
            userGuess[y] = PLACEHOLDER;
            Console.Write($"{PLACEHOLDER} ");
        }

        Console.WriteLine("\n");

        while (numberOfAttempts < NUMBER_OF_GUESSES)
        {
            numberOfAttempts++;
            char letterGuess = Console.ReadLine()[0];
            lettersAlreadyGuessed.Add(letterGuess);
            for (int x = 0; x < wordLength; x++)
            {
                if (letterGuess == wordToGuess[x])
                {
                    userGuess[x] = letterGuess;
                    Console.WriteLine(userGuess);
                    correctLetter++;
                }   
            }

            if (numberOfAttempts == NUMBER_OF_GUESSES)
            {
                Console.WriteLine("You've reached the max number of attempts. Game over.");
            }

            if (userGuess.Contains(PLACEHOLDER))
            {
                Console.WriteLine("Guess another letter");
            }

            else
            {
                Console.WriteLine("You guessed the mystery word. You won!");
            }
        }

    }

}