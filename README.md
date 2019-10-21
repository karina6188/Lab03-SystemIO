# Lab03-SystemIO

## About This Program
Word Guess Game

Author: Karina Chen

## Description
This is a C# console application that allows the user to play a word guess game. The user will see a main menu once the program is opened.

The user can choose to 1) view all the guess words, 2) add a new word, 3) remove a word, 4) start a game, or 5) exit the game.

The word guess game shows a hidden word and asks the user to guess the characters of the word. The user only knows the length of the word. If the user input matches any of the characters of the word,the character becomes visible. The user needs to keep guessing the correct characters of the word until all the characters are visible. Then the user wins the game.

## Getting Started
Clone this repository to your local machine.

$ git clone [https://github.com/karina6188/Lab03-SystemIO.git]

To run the program from Visual Studio:
Select File -> Open -> Project/Solution

Next navigate to the location you cloned the Repository.

Double click on the Lab03-SystemIO directory.

Then select and open lab03-system-io.

## To Run This Program
Open the program using Visual Studio and click "Start" button to run this program.

## Visuals

Domain Modeling

This drawing illustrates the main functions for this program. Each function has been detailed to include smaller functions that fullfil the requirements for this program. See summary comments in the program for more details.

![Alt execution capture](/captures/domain_modeling.jpg)

Application Start

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_start.JPG)

Using the Application - Start Game

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_start_game.JPG)

Using the Application - View Words

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_view_words.JPG)

Using the Application - Add Words

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_add_words.JPG)
![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_add_words2.JPG)

Using the Application - Remove Words

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_remove_words.JPG)
![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_remove_words2.JPG)

Application End

![Alt execution capture](https://github.com/karina6188/Lab03-SystemIO/blob/karina-lab03/captures/app_exit.JPG)

# Resource
Reference to Regex IsMatch method from this link:
https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426

## Change Log

1.1: Set up the program and added UserInterface method. - 2019 Oct 18

1.2: Added txt file and added AddWords method. Now the user can add words to the txt file. - 2019 Oct 19

1.3: For AddWords, add conditions to check if the user enters a valid input. If not, the word will not be added. - 2019 Oct 19

1.4: Add RemoveWords method that removes the word from txt file. - 2019 Oct 19

1.5: Modify AddWords method so the user must enters a word that contains only characters. - 2019 Oct 19

1.6: Modify RemoveWords method that the user can remove a word from the file as long as the file has the word. The word does not need to be case sensitive. - 2019 Oct 19

1.7: Add GenerateRandom method for StartGame method to randomly select a guess word from the file. - 2019 Oct 19

1.8: Add codes to take in user's input one character at a time, and check if user's guesses match the guess word. - 2019 Oct 19

1.9: Add codes to show underscores to the console that the length of the underscores matches with the length of the guess word. - 2019 Oct 20

1.10: Add codes to replace the underscores with the correct characters once the user guesses correctly. - 2019 Oct 20

1.11: Add conditions to break out from the while loop once all the characters are guessed. - 2019 Oct 20

1.12: Add summary comments, try and catch blocks, and checks or any bugs. - 2019 Oct 20

1.13: Add unit testing and pass all the tests. The program is completed. - 2019 Oct 20
