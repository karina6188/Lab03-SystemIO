using System;
using Xunit;
using System.IO;
using static lab03_system_io.Program;

namespace WordGuessTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddNewWord()
        {
            string path = "../../../../testWords.txt";
            string[] newWord = { "apple" };
            Assert.Equal(newWord[0], AddWords(path, newWord)[3]);
        }

        [Fact]
        public void ViewAllWords()
        {
            string path = "../../../../testWords.txt";
            string[] newWord = { "orange" };
            string[] forTest = File.ReadAllLines(path);
            int forTestLength = forTest.Length;
            Assert.Equal(forTestLength, ViewWords(path));
        }

        [Fact]
        public void RemoveWord()
        {
            string path = "../../../../testWords.txt";
            string[] removeWord = { "grapes" };
            Assert.Equal("no", RemoveWords(path, removeWord));
        }
    }
}
