#!/usr/bin/env dotnet-script

using System;

const int MAX_NUMBER = 100;
const int MIN_NUMBER = 1;

int randmomNumber = new Random().Next(1, 100);

Console.WriteLine("Guess a number between {0} and {1}", MIN_NUMBER, MAX_NUMBER);

int guess = -1;
while (guess != randmomNumber)
{

    Console.Write("Enter your guess: ");
    guess = int.Parse(Console.ReadLine());
    Console.Clear();
    if (guess < randmomNumber)
    {
        Console.WriteLine("Too low");
    }
    else if (guess > randmomNumber)
    {
        Console.WriteLine("Too high");
    }
    else
    {
        Console.WriteLine("You guessed it!");
    }

}