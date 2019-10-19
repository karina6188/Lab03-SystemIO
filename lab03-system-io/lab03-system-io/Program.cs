using System;
using System.IO;

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
                        Console.WriteLine("Enter a character to guess the word.");
                        StartGame();
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
                        string removeWord = Console.ReadLine();
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

        public static void RemoveWords(string path, string word)
        {
            string allWords = File.ReadAllText(path);
            string[] newWordsArray = new string[allWords.Length - 1];
            for (int i = 0; i < allWords.Length; i++)
            {
                if (allWords.Contains(word))
                {
                    Console.WriteLine("THIS WORKS");
                    Console.ReadLine();
                }
            }

  
            for (int i = 0; i < newWordsArray.Length; i++)
            {

            }
        }

        public static void AddWords(string path, string[] word)
        {
            if (word[0].Length > 0)
            {
                File.AppendAllLines(path, word);
            }
        }

        public static void StartGame()
        {
            char guessCharacter = Console.ReadLine()[0];
        }
    }
}