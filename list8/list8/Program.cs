using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace list8
{
    public class Program
    {

        public static Dictionary<string, int> wordsMap = new Dictionary<string, int>();
        public static List<string> wordsList = new List<string>();

        public static void addToDictionary(string word)
        {
            if (wordsMap.ContainsKey(word))
                wordsMap[word]++;
            else
                wordsMap.Add(word, 1);
        }

        public static void partWord(string word)
        {
            if (word != "")
            {
                foreach (char letter in word)
                {
                    if ((letter < 'A' || letter > 'Z') && (letter < 'a' || letter > 'z'))
                    {
                        int length = word.IndexOf(letter);
                        if (length > 0)
                        {
                            string newWord = word.Substring(0, length);
                            wordsList.Add(newWord);
                            addToDictionary(newWord);
                        }
                        if (length < word.Length - 1)
                            partWord(word.Substring(length + 1, word.Length - length - 1));
                        return;
                    }
                }
                addToDictionary(word);
                wordsList.Add(word);
            }
        }


        public static void readPath(string path)
        {

            using (var sr = new StreamReader(path))
            {
                List<string> words = new List<string>(sr.ReadToEnd().Split(' '));

                foreach (string word in words)
                {
                    partWord(word.ToLower());
                }

            }
        }

        public static void zad2()
        {
            string path = Console.ReadLine();

            try
            {
                readPath(path);
                //partWord("+-The'dad%thE9dad#$-+dad's the".ToLower());

                wordsMap = wordsMap.OrderByDescending(obj => obj.Value).ToDictionary(obj => obj.Key, obj => obj.Value);

                foreach (var pair in wordsMap)
                {
                    Console.WriteLine("Word: {0}, Frequency: {1}", pair.Key, pair.Value);
                }

                Console.WriteLine();

                foreach (var pair in wordsMap.Take(10))
                {
                    Console.WriteLine("Word: {0}, Frequency: {1}", pair.Key, pair.Value);
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            catch (ArgumentException e)
            {
                Console.WriteLine("Empty path provided:");
                Console.WriteLine(e.Message);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unsufficent privilages to open file:");
                Console.WriteLine(e.Message);
            }
        }

        static void zad3()
        {
            string path = Console.ReadLine();

            if(path == "")
            {
                Console.WriteLine("Empty path provided");
                return;
            }

            string curFile = path;
            if (File.Exists(curFile)) {
                readPath(path);
            }
            else
            {
                Console.WriteLine("The file could not be read");
            }

        }


        static void Main(string[] args)
        {
            //zad2();
            zad3();
        }

    }
}

