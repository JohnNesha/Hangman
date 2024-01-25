namespace Hangman1;

class Program
{
    public const int NUMBER_OF_GUESSES = 10;
    public const char PLACEHOLDER = '_';

    static void Main(string[] args)
    {
        Console.WriteLine("Let's play Hangman! Guess the letters to complete the word!\n");
        Console.WriteLine($"You have {NUMBER_OF_GUESSES} chances to guess the word. Let's begin!\n");

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
            char letterGuess = Console.ReadKey().KeyChar;

            //If users enters Null value such as hitting enter without enter letter
            if (letterGuess == '\0')
            {
                Console.WriteLine("You have entered an invalid character. Please enter a letter");
            }
            else
            {
                lettersAlreadyGuessed.Add(letterGuess);
            }
            Console.WriteLine($"These are the letters you have guessed: ");
            //Output for all letters guessed
            foreach (char item in lettersAlreadyGuessed)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");

            //Check if letter is in word
            if (wordToGuess.Contains(letterGuess))
            {
                for (int x = 0; x < wordLength; x++)
                {
                    if (wordToGuess[x] == letterGuess)
                    {
                        userGuess[x] = letterGuess;
                    }
                }
                Console.WriteLine(userGuess);
            }
            else
            {
                numberOfAttempts++;
                Console.WriteLine($"Guesses you have remaining: " + (NUMBER_OF_GUESSES - numberOfAttempts));
            }

            //Checks for dashes 
            if (userGuess.Contains(PLACEHOLDER))
            {
                Console.WriteLine("\nGuess another letter\n");
            }
            else
            {
                Console.WriteLine("\nYou guessed the mystery word. You won!");
                break;
            }
        }
        //If user reaches the max number of attempts 
        if (numberOfAttempts == NUMBER_OF_GUESSES)
        {
            Console.WriteLine("\nYou've reached the max number of attempts. Game over.\n");
            Console.WriteLine($"The secret word was {wordToGuess}");
        }

        Console.ReadKey();
    }
}