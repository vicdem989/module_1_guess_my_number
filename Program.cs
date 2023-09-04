// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;



/*

explain how game work

stats per round and per game

change background color on impossible

make all language checks if(Engish) {}

Add numeric value to each difficulty
        


*/


class CoreGame
{
    public static int minNumber = 1;
    public static int maxNumber = 100;
    public static int randmomNumber = new Random().Next(1, 100);
    public static int guess = -1;
    public static int correctGuesses = 0;
    public static int currentRound = 1;
    public static int wrongGuesses = 0;
    public static int maxGuesses = 5;
    public static string difficulty = "";
    public static bool ready = false;
    public static bool english = true;
    public static bool rematch = true;
    
    public static void Main(string[] args)
    {
        Console.Clear();
        CoreGame.ChooseLanguage();
        CoreGame.StartGame();
        while (rematch)
        {
            CoreGame.Replay();
        }
        CoreGame.stats();
    }

    static void StartGame()
    {
        CoreGame.ChooseDifficulty();
        Console.Clear();
        CoreGame.StartText();
        while (maxGuesses != wrongGuesses)
        {
            CoreGame.Round();
        }
    }
    static void Replay()
    {
        Console.WriteLine("Do you want to play again? y/n");
        if (string.Equals(Console.ReadLine(), "y"))
        {
            rematch = true;
            wrongGuesses = 0;
            CoreGame.StartGame();
        }
        rematch = false;
    }
    static void ChooseLanguage()
    {
        Console.WriteLine("Do you want English or Norwegian?");
        string language = Console.ReadLine().ToLower();
        if ((string.Equals(language, "english")) || (string.Equals(language, "en")) || (string.Equals(language, "engelsk")))
        {
            english = true;
        }
        else if ((string.Equals(language, "norwegian")) || (string.Equals(language, "no")) || (string.Equals(language, "norsk")))
        {
            english = false;
        }
        else
        {
            CoreGame.ChooseLanguage();
        }
    }
    static void StartText()
    {
        if ((string.Compare(difficulty, "Easy") == 0) || (string.Compare(difficulty, "Lett") == 0))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        else if ((string.Compare(difficulty, "Medium") == 0) || (string.Compare(difficulty, "Medium") == 0))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if ((string.Compare(difficulty, "Hard") == 0) || (string.Compare(difficulty, "Vanskelig") == 0))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if ((string.Compare(difficulty, "Impossible") == 0) || (string.Compare(difficulty, "Morroskyld") == 0))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        if (english)
        {
            Console.WriteLine("You chose " + difficulty + " difficulty.");
            Console.ResetColor();
            Console.WriteLine("Total guesses: " + maxGuesses);
            Console.WriteLine("\n" + "Guess a number between {0} og {1}", minNumber, maxNumber);
        }
        else
        {
            Console.WriteLine("Du valgte " + difficulty + " vanskelighetsgrad.");
            Console.ResetColor();
            Console.WriteLine("Totale gjett: " + maxGuesses);
            Console.WriteLine("\n" + "Gjett et tall mellom {0} og {1}", minNumber, maxNumber);
        }
    }
    static void EasyDifficulty()
    {
        CoreGame.maxGuesses = 25;
        CoreGame.maxNumber = 50;
    }
    static void MediumDifficulty()
    {
        CoreGame.maxGuesses = 15;
        CoreGame.maxNumber = 75;
    }
    static void HardDifficulty()
    {
        CoreGame.maxGuesses = 10;
        CoreGame.maxNumber = 100;
    }
    static void ImpossibleDifficulty()
    {
        CoreGame.maxGuesses = 3;
        CoreGame.maxNumber = 200;
    }
    static void FunDifficulty()
    {
        CoreGame.minNumber = new Random().Next(1, 100);
        CoreGame.maxNumber = new Random().Next(1, 100);
        while (maxNumber < minNumber)
        {
            CoreGame.minNumber = new Random().Next(1, 100);
            CoreGame.maxNumber = new Random().Next(1, 100);
        }
        if (maxNumber > minNumber)
        {
            CoreGame.maxGuesses = new Random().Next(1, CoreGame.minNumber);
        }
    }
    static void ChooseDifficulty()
    {
        if (!english)
        {
            Console.WriteLine("Hvilken vanskelighetsgrad onsker du?"); 
            Console.WriteLine("Lett, Medium, Vanskelig, Umulig eller Morroskyld");
        }
        else
        {
            Console.WriteLine("What difficulty do you want?");
            Console.WriteLine("Easy, Medium, Hard, Impossible or Fun");
        }

        difficulty = Console.ReadLine().ToLower();      

        if ((difficulty == "fun") || (difficulty == "morroskyld"))
        {
            CoreGame.FunDifficulty();
            ready = true;
            return;
        }

        if ((difficulty == "easy") || (difficulty == "lett"))
        {
            CoreGame.EasyDifficulty();
            ready = true;
        }
        else if ((difficulty == "medium") || (difficulty == "medium"))
        {
            CoreGame.MediumDifficulty();
            ready = true;
        }
        else if ((difficulty == "hard") || (difficulty == "vanskelig"))
        {
            CoreGame.HardDifficulty();
            ready = true;
        }
        else if ((difficulty == "impossible") || (difficulty == "umulig"))
        {
            CoreGame.ImpossibleDifficulty();
            ready = true;
        }
        minNumber = 1;
        if (!ready)
        {
            CoreGame.ChooseDifficulty();
        }
    
    }

    static void Round()
    {
        ApplicationStrings appTextEN = new ApplicationStrings
        {
            EnterYourGuess = "Round {0} - Enter your guess: ",
            InputNumber = "Please input a number",
            TooLow = "Too low",
            TooHigh = "Too high",
            YouGuessedIt = "You guessed it!",
            GuessesLeft = "Guesses left: "
        };
        ApplicationStrings appTextNO = new ApplicationStrings
        {
            EnterYourGuess = "Runde {0} - Skriv inn ditt gjett: ",
            InputNumber = "Skriv inn et tall",
            TooLow = "For lavt",
            TooHigh = "For høyt",
            YouGuessedIt = "Du gjettet riktig!",
            GuessesLeft = "Gjettninger igjen: "
        };
        ApplicationStrings[] languages = new ApplicationStrings[2];
        languages[0] = appTextEN;
        languages[1] = appTextNO;

        if (english)
        {
            languages.SetValue(appTextEN, 0);
        }
        else
        {
            languages.SetValue(appTextNO, 0);
        }
        CoreGame.randmomNumber = new Random().Next(minNumber, maxNumber);
        CoreGame.wrongGuesses = 0;
        while (maxGuesses != wrongGuesses)
        {
            Console.Write("Answer: " + randmomNumber + "\n");
            Console.WriteLine(languages[0].EnterYourGuess, CoreGame.currentRound);
            var input = Console.ReadLine();
            var test = int.TryParse(input, out var result);
            if (!test)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(languages[0].InputNumber);
                Console.ResetColor();
                continue;
            }
            CoreGame.guess = int.Parse(input);
            Console.Clear();

            if (guess < randmomNumber)
            {
                CoreGame.setTextColor();
                Console.WriteLine($""+languages[0].TooLow, CoreGame.currentRound);
                CoreGame.wrongGuesses++;
            }
            else if (guess > randmomNumber)
            {
                CoreGame.setTextColor();
                Console.WriteLine($""+languages[0].TooHigh, CoreGame.currentRound);
                CoreGame.wrongGuesses++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($""+languages[0].YouGuessedIt, CoreGame.currentRound);
                CoreGame.correctGuesses++;
                CoreGame.currentRound++;
                CoreGame.randmomNumber = new Random().Next(minNumber, maxNumber);
            }
            Console.ResetColor();

            int guessesLeft = maxGuesses - wrongGuesses;
            Console.ForegroundColor = ConsoleColor.Red;
            if (guessesLeft > maxGuesses / 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (guessesLeft > (maxGuesses / 4))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(""+languages[0].GuessesLeft + (maxGuesses - wrongGuesses));
            Console.ResetColor();
        }
    }
    static void stats()
    {
        float avgWrongGuessesPerRound = (float)CoreGame.wrongGuesses / (float)CoreGame.correctGuesses;
        Console.Clear();
        if (english)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You got " + CoreGame.correctGuesses + " correct guesses!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Total of " + CoreGame.wrongGuesses + " wrong Guesses");
            Console.ResetColor();
            Console.WriteLine("Per round average wrong guesses are: {0:N2}", avgWrongGuessesPerRound);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Du har " + CoreGame.correctGuesses + " riktige svar!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Totalt " + CoreGame.wrongGuesses + " feil svar!");
            Console.ResetColor();
            Console.WriteLine("Gjennomsnittelig feil gjett per runde er: {0:N2}", avgWrongGuessesPerRound);
        }
    }
    static void setTextColor()
    {
        if ((guess > (randmomNumber - 10)) && (guess < (randmomNumber + 10)))
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
class ApplicationStrings
{
    public string Guess { get; set; }
    public string TooLow { get; set; }
    public string TooHigh { get; set; }
    public string YouGuessedIt { get; set; }
    public string EnterYourGuess { get; set; }
    public string GuessANumberBetween { get; set; }
    public string InputNumber { get; set; }
    public string GuessesLeft { get; set; }
}