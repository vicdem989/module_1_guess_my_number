// See https://aka.ms/new-console-template for more information

const int MAX_NUMBER = 100;
const int MIN_NUMBER = 1;

ApplicationStrings appText = new ApplicationStrings
{
    Guess = "Guess",
    TooLow = "Too low",
    TooHigh = "Too high",
    YouGuessedIt = "You guessed it!",
    EnterYourGuess = "Enter your guess: ",
    GuessANumberBetween = "Guess a number between {0} and {1}"
};

int randmomNumber = new Random().Next(1, 100);

Console.WriteLine(appText.GuessANumberBetween, MIN_NUMBER, MAX_NUMBER);

int guess = -1;
while (guess != randmomNumber)
{

    Console.Write(appText.EnterYourGuess);
    guess = int.Parse(Console.ReadLine());
    Console.Clear();
    if (guess < randmomNumber)
    {
        Console.WriteLine(appText.TooLow);
    }
    else if (guess > randmomNumber)
    {
        Console.WriteLine(appText.TooHigh);
    }
    else
    {
        Console.WriteLine(appText.YouGuessedIt);
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
