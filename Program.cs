﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        /*
            First string (tests[0]) Values:
            Total Words: 14
            Total Characters: 89
            Character count (minus line returns and spaces): 60
            Most used word: the (2 times)
            Most used character: e (10 times)

            Second string (tests[1]) Values:
            Total Words: 45
            Total Characters: 276
            Character count (minus line returns and spaces): 230
            Most used word: the (6 times)
            Most used character: t (24 times)
        */

        static void Main(string[] args)
        {
            foreach (string test in tests)
            {
                string filteredTest = test.Replace(Environment.NewLine, " ");
                // total character count
                GetTotalCharacters(filteredTest);
                //number of non-white space/ non-line return character
                GetNonWhiteSpaceCharacters(filteredTest);
                //number of words in a string
                List<string> words = GetWordsFromString(filteredTest);
                // list of words
                words.ForEach(word => Console.WriteLine(word));
                Console.WriteLine();

                
            }

            Console.ReadLine();
        }

        private static List<string> GetWordsFromString(string filteredTest)
        {
            List<string> output;
            Regex alpaCheck = new Regex("[^a-zA-Z ]");
            string cleanedTest = alpaCheck.Replace(filteredTest, "");

            output = cleanedTest.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            Console.WriteLine($"Total words: { output.Count() }");

            return output;
        }

        private static void GetNonWhiteSpaceCharacters(string filteredTest)
        {
            Console.WriteLine($"Total non-white space characters: { filteredTest.Where(x => x != ' ')}");
        }

        private static void GetTotalCharacters(string filteredTest)
        {
            Console.WriteLine($"total characters: { filteredTest.Length }");
        }
    }
}
