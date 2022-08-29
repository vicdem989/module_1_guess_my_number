import random

MAX_NUMBER = 100
MIN_NUMBER = 1

randomNumber = random.randint(MIN_NUMBER, MAX_NUMBER)
isPlaying = True

print("Guess a number between 1 and 100")

while isPlaying:
    guess = int(input("Your guess: "))
    if guess == randomNumber:
        print("You guessed it!")
        isPlaying = False
    elif guess > randomNumber:
        print("Too high")
    else:
        print("Too low")
