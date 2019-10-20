using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab03_system_io
{
    class Program
    {
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

        public static void ViewWords(string path)
        {
            string[] allWords = File.ReadAllLines(path);
            foreach(string word in allWords)
            {
                Console.WriteLine(word);
            }
        }

        public static void RemoveWords(string path, string[] word)
        {
            string[] allWords = File.ReadAllLines(path);
            string[] newWordsArray = new string[allWords.Length - 1];
            int indexFound = -1;
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
        
        public static void AddWords(string path, string[] word)
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

        public static void StartGame(string path)
        {
            string[] allWords = File.ReadAllLines(path);
            GenerateRandom(allWords);
            int randomNumber = (GenerateRandom(allWords));
            string guessWord = allWords[randomNumber];
            int guessWordLength = guessWord.Length;
            string path2 = "../../../../matchGuessWords.txt";

            MatchGuessWord(path2, guessWord);
            string[] replaceHidden = MatchGuessWord(path2, guessWord);
            Console.WriteLine($"{guessWord}");
            Console.WriteLine($"{guessWordLength}");
            Console.WriteLine()

            bool notWin = true;
            while (notWin)
            {
                char guess = Console.ReadLine()[0];
                for (int i = 0; i < guessWord.Length; i++)
                {
                    if (guessWord[i] == guess)
                    {
                        replaceHidden[i] = guess.ToString();
                        Console.WriteLine("HERE");
                    }
                }
                Console.Write(replaceHidden.ToString());
                //if(guessWord.Contains(guess))
                //{
                //    Console.WriteLine("CORRECT");
                //    Console.WriteLine($"{guess}");
                //    Console.ReadLine();
                //    notWin = false;
                //}
                //else
                //{
                //    Console.WriteLine($"The letter you guessed: {guess}");
                //    Console.WriteLine("WRONG");
                //    notWin = true;
                //}
            }
        }

        static string[] MatchGuessWord(string path, string guessWord)
        {
            string[] hidden = new string[guessWord.Length];
            for (int i = 0; i < guessWord.Length; i++)
            {
                hidden[i] = "_ ";
                Console.Write(hidden[0]);
            }
            return hidden;
        }

        public static int GenerateRandom(string[] allWords)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, allWords.Length - 1);
            return randomNumber;
        }
    }
}