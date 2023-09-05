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
        ApplicationStrings appText = CoreGame.ChooseLanguage();
        while (rematch)
        {
            CoreGame.StartGame(appText);
        }
        CoreGame.Stats(appText);
    }

    static void StartGame(ApplicationStrings appText)
    {
        CoreGame.ChooseDifficulty(appText);
        Console.Clear();
        CoreGame.StartText(appText);
        while (maxGuesses != wrongGuesses)
        {
            CoreGame.Round(appText);
        }
        Console.WriteLine("Do you want to play again? y/n");
        if (string.Equals(Console.ReadLine(), "n"))
        {
            rematch = false;
        }
        Console.Clear();
        wrongGuesses = 0;
    }
    public static ApplicationStrings ChooseLanguage()
    {
        Console.Clear();
        Console.WriteLine("Do you want English or Norwegian?");
        string language = Console.ReadLine().ToLower();
        bool validLanguage = false;
        Console.Clear();
        if ((string.Equals(language, "english")) || (string.Equals(language, "en")) || (string.Equals(language, "engelsk")) || (string.Equals(language, "norwegian")) || (string.Equals(language, "no")) || (string.Equals(language, "norsk")))
        {
            validLanguage = true;
        }
        if ((string.Equals(language, "english")) || (string.Equals(language, "en")) || (string.Equals(language, "engelsk")) && validLanguage)
        {
            return new ApplicationStrings
            {
                EnterYourGuess = " Enter your guess: ",
                InputNumber = "Please input a number",
                TooLow = "Too low",
                TooHigh = "Too high",
                YouGuessedIt = "You guessed it!",
                GuessesLeft = "Guesses left: ",
                RoundNumber = "Round - ",
                YouChose = "You chose ",
                ChosenDifficulty = " difficulty",
                TotalGuesses = "Total guesses: ",
                WhatDifficulty = "What difficulty do you want?",
                DifficultyList = "Easy, Medium, Hard, Impossible or Fun",
                WrongInput = "Please input a number",
                StatsCorrectGuesses = "Total correct guesses: ",
                StatsWrongGuesses = "Total wrong guesses: ",
                StatsPerRoundAverage = "Average wrong guess per round: ",
                GuessANumberBetween = "Guess a number between: "
            };
        }
        else if ((string.Equals(language, "norwegian")) || (string.Equals(language, "no")) || (string.Equals(language, "norsk")) && validLanguage)
        {
            return new ApplicationStrings
            {
                EnterYourGuess = " Skriv inn ditt gjett: ",
                InputNumber = "Skriv inn et tall",
                TooLow = "For lavt",
                TooHigh = "For høyt",
                YouGuessedIt = "Du gjettet riktig!",
                GuessesLeft = "Gjettninger igjen: ",
                RoundNumber = "Runde - ",
                YouChose = "Du valgte ",
                ChosenDifficulty = " vanskelighetsgrad",
                TotalGuesses = "Totale gjett: ",
                WhatDifficulty = "Hvilken vanskelighetsgrad onsker du?",
                DifficultyList = "Lett, Medium, Vanskelig, Umulig eller Morroskyld",
                WrongInput = "Skriv inn et tall",
                StatsCorrectGuesses = "Totalt riktige gjett: ",
                StatsWrongGuesses = "Totale feil gjett: ",
                StatsPerRoundAverage = "Gjennomsnittelig feil gjett per runde: ",
                GuessANumberBetween = "Gjett et tall mellom: "
            };
        }
        else
        {
            return CoreGame.ChooseLanguage();
        }
    }
    static void StartText(ApplicationStrings appText)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
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

        Console.WriteLine(appText.YouChose + difficulty + appText.ChosenDifficulty);
        Console.ResetColor();
        Console.WriteLine(appText.TotalGuesses);
        Console.WriteLine(appText.GuessANumberBetween + minNumber + " - " + maxNumber);
    }
    static void EasyDifficulty() //Call startext easy text here ------------------------------------------------------------------------------------------------------------------------------------------------------
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
    static void ChooseDifficulty(ApplicationStrings appText)
    {
        Console.WriteLine(appText.WhatDifficulty);
        Console.WriteLine(appText.DifficultyList);
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
        else
        {
            Console.Clear();
            CoreGame.ChooseDifficulty(appText);
        }
        minNumber = 1;

    }

    static void Round(ApplicationStrings appText)
    {
        CoreGame.randmomNumber = new Random().Next(minNumber, maxNumber);
        CoreGame.wrongGuesses = 0;
        while (maxGuesses != wrongGuesses)
        {
            Console.Write("Answer: " + randmomNumber + "\n");
            Console.WriteLine(appText.RoundNumber + currentRound + appText.EnterYourGuess);

            var input = Console.ReadLine();
            var test = int.TryParse(input, out var result);
            if (!test)
            {
                Console.Clear();
                continue;
            }
            CoreGame.guess = int.Parse(input);
            Console.Clear();

            if (guess < randmomNumber)
            {
                CoreGame.setTextColor();
                Console.WriteLine($"" + appText.TooLow, CoreGame.currentRound);
                CoreGame.wrongGuesses++;
            }
            else if (guess > randmomNumber)
            {
                CoreGame.setTextColor();
                Console.WriteLine($"" + appText.TooHigh, CoreGame.currentRound);
                CoreGame.wrongGuesses++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"" + appText.YouGuessedIt, CoreGame.currentRound);
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
            Console.WriteLine("" + appText.GuessesLeft + (maxGuesses - wrongGuesses));
            Console.ResetColor();
        }
    }

    static void changeColor(System.ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    static void Stats(ApplicationStrings appText)
    {
        float avgWrongGuessesPerRound = (float)CoreGame.wrongGuesses / (float)CoreGame.correctGuesses;
        Console.Clear();

        CoreGame.changeColor(ConsoleColor.Green, appText.StatsCorrectGuesses + CoreGame.correctGuesses);
        CoreGame.changeColor(ConsoleColor.Red, appText.StatsWrongGuesses + CoreGame.wrongGuesses);
        Console.WriteLine(appText.StatsPerRoundAverage + avgWrongGuessesPerRound);

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
    public string GuessANumberBetween { get; set; }
    public string StatsCorrectGuesses { get; set; }
    public string StatsWrongGuesses { get; set; }
    public string StatsPerRoundAverage { get; set; }
    public string WrongInput { get; set; }
    public string WhatDifficulty { get; set; }
    public string DifficultyList { get; set; }
    public string YouChose { get; set; }
    public string ChosenDifficulty { get; set; }
    public string TotalGuesses { get; set; }
    public string RoundNumber { get; set; }
    public string TooLow { get; set; }
    public string TooHigh { get; set; }
    public string YouGuessedIt { get; set; }
    public string EnterYourGuess { get; set; }
    public string InputNumber { get; set; }
    public string GuessesLeft { get; set; }

}
