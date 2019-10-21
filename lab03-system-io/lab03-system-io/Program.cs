using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab03_system_io
{
    class Program
    {
        /// <summary>
        /// Main method is to handle all the exceptions that are not catched by
        /// other methods. This method calls UserInterface method which is the
        /// main menu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                bool game = true;
                while (game)
                {
                    game = UserInterface();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This is the main menu and calls all the other methods based on the
        /// user's selections.
        /// </summary>
        /// <returns></returns>
        public static bool UserInterface()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Word Guess Game!");
            Console.WriteLine("Choose from the following menu to start.");
            Console.WriteLine("1) Start a Game");
            Console.WriteLine("2) View Words");
            Console.WriteLine("3) Add Words");
            Console.WriteLine("4) Remove Words");
            Console.WriteLine("5) Exit");
            string selection = Console.ReadLine();
            string path = "../../../../guessWords.txt";
            try
            {
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Let's start the game!");
                        Console.WriteLine("Enter characters to guess the word.");
                        StartGame(path);
                        Console.WriteLine("Congratulations! You win the game!!");
                        Console.ReadLine();
                        return true;

                    case "2":
                        ViewWords(path);
                        Console.ReadLine();
                        return true;

                    case "3":
                        Console.WriteLine("Enter a word that you want to add to the game.");
                        string[] newWord = { Console.ReadLine() };
                        AddWords(path, newWord);
                        return true;

                    case "4":
                        Console.WriteLine("Enter a word that you want to remove from the game.");
                        string[] removeWord = { Console.ReadLine() };
                        RemoveWords(path, removeWord);
                        return true;

                    case "5":
                        Console.WriteLine("Bye bye! See you next time.");
                        Console.ReadLine();
                        return false;

                    default:
                        Console.WriteLine("Your selection is invalid.");
                        Console.WriteLine("Please select from the available options.");
                        Console.ReadLine();
                        return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("That is not a valid entry.");
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return true;
            }
        }

        /// <summary>
        /// ViewWords reads all the texts from guessWords.txt to show in the console.
        /// </summary>
        /// <param name="path"></param>
        public static void ViewWords(string path)
        {
            try
            {
                string[] allWords = File.ReadAllLines(path);
                foreach (string word in allWords)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There is something wrong with the txt file.");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// RemoveWords takes in user's word and check if the word exists in the txt
        /// file. The word is checked case insensitive. Once the word is found, the
        /// txt file is rewritten with only the words that are not removed. The words
        /// are then shown in the console. If the word is not found, no changes are
        /// made to the txt file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="word"></param>
        public static void RemoveWords(string path, string[] word)
        {
            try
            {
                string[] allWords = File.ReadAllLines(path);
                string[] newWordsArray = new string[allWords.Length - 1];
                int indexFound;
                for (int i = 0; i < allWords.Length; i++)
                {
                    string word1 = word[0].ToLower();
                    if (allWords[i].Contains(word1))
                    {
                        indexFound = i;
                        RemoveAction(allWords, newWordsArray, indexFound);
                        File.WriteAllLines(path, newWordsArray);
                    }
                    else
                    {
                        File.WriteAllLines(path, allWords);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This method is to support RemoveWords method in order to put the non-removed
        /// words into a new array. 
        /// </summary>
        /// <param name="allWords"></param>
        /// <param name="newWordsArray"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string[] RemoveAction(string[] allWords, string[] newWordsArray, int index)
        {
            for (int i = 0; i < allWords.Length; i++)
            {
                if (i < index)
                {
                    newWordsArray[i] = allWords[i];
                }
                if (i > index)
                {
                    newWordsArray[i - 1] = allWords[i];
                }
            }
            return newWordsArray;
        }

        /// <summary>
        /// AddWords checks if the user actually inputs valid characters only. If yes,
        /// the word is then added to the txt file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="word"></param>
        public static void AddWords(string path, string[] word)
        {
            try
            {
                if (word[0].Length > 0)
                {
                    if (Regex.IsMatch(word[0], @"^[a-zA-Z]+$"))
                    {
                        string word1 = word[0].ToLower();
                        string[] lowerWord = { word1 };
                        File.AppendAllLines(path, lowerWord);
                    }
                    else
                    {
                        Console.WriteLine("Please enter characters only.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a word.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// StartGame first randomly selects a word from the txt file. GenerateRandom
        /// method is created to support this action. Once a word is randomly selected,
        /// underscores are created to match with the length of the word. The method 
        /// then takes in user's input one character at a time to check if the character
        /// matches any characters in the guess word. The character is being checked
        /// case insensitively. If the character matches, the underscores are replaced
        /// with the correct characters at the correct positions. If the character does
        /// not matches any within the word, the underscores are printed to the console
        /// again until all the characters of the word are guessed correctly. Once this
        /// happens, it breaks out from the while loop and the user wins the game.
        /// </summary>
        /// <param name="path"></param>
        public static void StartGame(string path)
        {
            string[] allWords = File.ReadAllLines(path);
            GenerateRandom(allWords);
            int randomNumber = (GenerateRandom(allWords));
            string guessWord = allWords[randomNumber];
            int guessWordLength = guessWord.Length;

            string[] hidden = new string[guessWord.Length];
            for (int i = 0; i < guessWord.Length; i++)
            {
                hidden[i] = "_";
                Console.Write($"{hidden[0]} ");
            }
            //MatchGuessWord(guessWord);

            Console.WriteLine($"{guessWord}");
            Console.WriteLine($"{guessWordLength}");

            bool notWin = true;
            while (notWin)
            {
                char input = Console.ReadLine()[0];
                char guess = char.ToLower(input);
                for (int i = 0; i < guessWord.Length; i++)
                {
                    if (guessWord[i] == guess)
                    {
                        hidden[i] = guess.ToString();
                    }
                }
                foreach (string letter in hidden)
                {
                    Console.Write($"{letter} ");
                }
                foreach (string letter in hidden)
                {
                    if (!hidden.Contains("_"))
                    {
                        notWin = false;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"You entered a character: {input}");
            }
        }

        /// <summary>
        /// This is a helper method to support StartGame method. This method generates
        /// a random number between 0 and the number of total words in the txt file. 
        /// </summary>
        /// <param name="allWords"></param>
        /// <returns></returns>
        public static int GenerateRandom(string[] allWords)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, allWords.Length - 1);
            return randomNumber;
        }
    }
}