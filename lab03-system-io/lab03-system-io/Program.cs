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
            Console.WriteLine("1) View Words");
            Console.WriteLine("2) Remove Words");
            Console.WriteLine("3) Add Words");
            Console.WriteLine("4) Start a Game");
            Console.WriteLine("5) Exit");
            string selection = Console.ReadLine();
            string path = "../../guessWords.txt";
            try
            {
                switch (selection)
                {
                    case "1":
                        ViewWords(path);
                        return true;

                    case "2":
                        RemoveWords();
                        return true;

                    case "3":
                        AddWords();
                        return true;

                    case "4":
                        Console.WriteLine("Let's start the game!");
                        Console.WriteLine("Enter a character to guess the word.");
                        StartGame();
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
            string allWords = File.ReadAllText(path);
            Console.WriteLine(allWords);
        }

        public static void RemoveWords()
        {
            Console.WriteLine("Enter a word that you want to remove from the game.");
            string removeWord = Console.ReadLine();
        }

        public static void AddWords()
        {
            Console.WriteLine("Enter a word that you want to add to the game.");
            string addWord = Console.ReadLine();
        }

        public static void StartGame()
        {
            char guessCharacter = Console.ReadLine()[0];
        }
    }
}