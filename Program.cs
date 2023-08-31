// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
    public static bool rematch = false;


    public static void Main(string[] args)
    {

        CoreGame.ChooseLanguage();

        while (!ready)
        {
            CoreGame.ChooseDifficulty();
            Console.Clear();
        }

        CoreGame.StartText();

        randmomNumber = new Random().Next(minNumber, maxNumber);

        while (maxGuesses != wrongGuesses)
        {
            CoreGame.Round();
        }
        CoreGame.stats();

        while (!rematch) {
            if(english) {
                Console.WriteLine("Do you want to play again? y/n");
            } else {
                Console.WriteLine("Vil du spille igjen? y/n");
            }
            if(string.Compare(Console.ReadLine(), "y") == 0) {
                CoreGame.ChooseDifficulty();
                CoreGame.Round();
                rematch = false;
            } 
            rematch = true;
        }
        CoreGame.stats();

    }

    static void ChooseLanguage()
    {
        Console.WriteLine("Do you want English or Norwegian?");
        string language = Console.ReadLine();
        if (string.Equals(language, "English"))
        {
            english = true;
        }
        else if (string.Equals(language, "Norwegian"))
        {
            english = false;
        }
        else 
        {
            Console.WriteLine("Please choose either English or Norwegian.");
            CoreGame.ChooseLanguage();
        }
    }

    static void StartText()
    {

        ApplicationStrings appText = new ApplicationStrings
        {
            Guess = "Guess dsds",
            TooLow = "Too low",
            TooHigh = "Too high",
            YouGuessedIt = "You guessed it!",
            EnterYourGuess = "Enter your guess: ",
            GuessANumberBetween = "Guess a number between {0} and {1}"
        };

        ApplicationStrings appTextNorge = new ApplicationStrings

        {
            GuessANumberBetween = "Gjett et tall mellom {0} og {1}"
        };

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
        }
        else
        {
            Console.WriteLine("Du valgte " + difficulty + " vanskelighetsgrad.");
        }
        Console.ResetColor();
        if (!english)
        {
            Console.WriteLine("Totale gjett: " + maxGuesses);
        }
        else
        {
            Console.WriteLine("Total guesses: " + maxGuesses);
        }
        if (!english)
        {
            Console.WriteLine("\n" + appTextNorge.GuessANumberBetween, minNumber, maxNumber);
        }
        else
        {
            Console.WriteLine("\n" + appText.GuessANumberBetween, minNumber, maxNumber);
        }
    }

    static void EasyDifficulty()
    {
        CoreGame.maxGuesses = 25;
        CoreGame.minNumber = 1;
        CoreGame.maxNumber = 50;
    }

    static void MediumDifficulty()
    {
        CoreGame.maxGuesses = 15;
        CoreGame.minNumber = 1;
        CoreGame.maxNumber = 75;
    }

    static void HardDifficulty()
    {
        CoreGame.maxGuesses = 10;
        CoreGame.minNumber = 1;
        CoreGame.maxNumber = 100;
    }

    static void ImpossibleDifficulty()
    {
        CoreGame.maxGuesses = 3;
        CoreGame.minNumber = 1;
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
        }
        else
        {
            Console.WriteLine("What difficulty do you want?");
        }

        difficulty = Console.ReadLine();
        if ((difficulty == "Easy") || (difficulty == "Lett"))
        {
            CoreGame.EasyDifficulty();
            ready = true;
        }
        else if ((difficulty == "Medium") || (difficulty == "Medium"))
        {
            CoreGame.MediumDifficulty();
            ready = true;
        }
        else if ((difficulty == "Hard") || (difficulty == "Vanskelig"))
        {
            CoreGame.HardDifficulty();
            ready = true;
        }
        else if ((difficulty == "Impossible") || (difficulty == "Umulig"))
        {
            CoreGame.ImpossibleDifficulty();
            ready = true;
        }
        else if ((difficulty == "Fun") || (difficulty == "Morroskyld"))
        {
            CoreGame.FunDifficulty();
            ready = true;
        }
        else
        {
            if (!english)
            {
                Console.WriteLine("Velg en vanskelighetsgrad. Du kan velge mellom: Lett, Medium, Vanskelig, Umulig eller Morroskyld.");
            }
            Console.WriteLine("Please input a difficulty. Choose between: Easy, Medium, Hard, Impossible or Fun.");
            difficulty = Console.ReadLine();
        }
    }

    static void Round()
    {

        ApplicationStrings appText = new ApplicationStrings

        {
            Guess = "Guess",
            TooLow = "Too low",
            TooHigh = "Too high",
            YouGuessedIt = "You guessed it!",
            EnterYourGuess = "Round {0} - Enter your guess: ",
            GuessANumberBetween = "Guess a number between {0} and {1}"
        };

        ApplicationStrings appTextNorge = new ApplicationStrings

        {
            Guess = "Gjett",
            TooLow = "For lavt",
            TooHigh = "For høyt",
            YouGuessedIt = "Du gjettet riktig!",
            EnterYourGuess = "Runde {0} - Skriv inn ditt gjett: ",
            GuessANumberBetween = "Gjett et tall mellom {0} og {1}"
        };

        CoreGame.randmomNumber = new Random().Next(minNumber, maxNumber);

        CoreGame.wrongGuesses = 0;

        while (maxGuesses != wrongGuesses)
        {

            Console.Write("Answer: " + randmomNumber + "\n");

            if (!english)
            {
                Console.WriteLine(appTextNorge.EnterYourGuess, CoreGame.currentRound);
            }
            else
            {
                Console.WriteLine(appText.EnterYourGuess, CoreGame.currentRound);
            }


            var input = Console.ReadLine();
            var test = int.TryParse(input, out var result);
            if (!test)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (english)
                {
                    Console.WriteLine("Please input a number");
                }
                else
                {
                    Console.WriteLine("Skriv inn et tall");
                }

                Console.ResetColor();
                continue;
            }

            CoreGame.guess = int.Parse(input);

            Console.Clear();

            if (guess < randmomNumber)
            {
                CoreGame.setTextColor();
                if (!english)
                {
                    Console.WriteLine(appTextNorge.TooLow, CoreGame.currentRound);
                }
                else
                {
                    Console.WriteLine(appText.TooLow, CoreGame.currentRound);
                }
                CoreGame.wrongGuesses++;
            }
            else if (guess > randmomNumber)
            {
                CoreGame.setTextColor();
                if (!english)
                {
                    Console.WriteLine(appTextNorge.TooHigh, CoreGame.currentRound);
                }
                else
                {
                    Console.WriteLine(appText.TooHigh, CoreGame.currentRound);
                }
                CoreGame.wrongGuesses++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (!english)
                {
                    Console.WriteLine(appTextNorge.YouGuessedIt, CoreGame.currentRound);
                }
                else
                {
                    Console.WriteLine(appText.YouGuessedIt, CoreGame.currentRound);
                }
                CoreGame.correctGuesses++;
                CoreGame.currentRound++;
                CoreGame.randmomNumber = new Random().Next(minNumber, maxNumber);

            }

            Console.ResetColor();
            int guessesLeft = maxGuesses - wrongGuesses;
            if (guessesLeft > maxGuesses / 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (guessesLeft > (maxGuesses / 4))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (english)
            {   
                Console.WriteLine("You have : " + (maxGuesses - wrongGuesses) + " guess(es) left!");
            }
            else
            {
                Console.WriteLine("Du har : " + (maxGuesses - wrongGuesses) + " gjett(er) igjen!"); 
            }

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
            Console.WriteLine("You got " + CoreGame.correctGuesses + " correct guesses!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total of " + CoreGame.wrongGuesses + " wrong Guesses");
            Console.ResetColor();

            Console.WriteLine("Per round average wrong guesses are: {0:N2}", avgWrongGuessesPerRound);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Du har " + CoreGame.correctGuesses + " riktige svar!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Totalt " + CoreGame.wrongGuesses + " feil svar!");
            Console.ResetColor();
            Console.WriteLine("Gjennomsnittelig feil gjett per runde er: {0:N2}", avgWrongGuessesPerRound);
        }
        Console.ResetColor();
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
}
