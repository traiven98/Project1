using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Program
{
    static int[] createArray(string filename)
    {
        int[] numberArray = new int[] { };

        using (StreamReader sr = new StreamReader(filename))
        {
            // Read the input file's content
            string inputText = sr.ReadToEnd();

            // Use a regular expression to extract all the numbers from the input text
            MatchCollection numbers = Regex.Matches(inputText, @"\d+");
            numberArray = numbers.Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();
        }
        return numberArray;
    }
    static int[] ReadNumbersFromTextFile(string filePath)
    {
        // Create a list to store the numbers
        var numbers = new List<int>();
        // Open the file using a StreamReader
        using (StreamReader sr = new StreamReader(filePath))
        {
            // Read the file one line at a time
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // Split the line into words
                string[] words = line.Split();
                // Iterate through each word
                foreach (string word in words)
                {
                    // Check if the word is a number
                    if (int.TryParse(word, out int number))
                    {
                        // If it is, add it to the list of numbers
                        numbers.Add(number);
                    }
                }
            }
        }
        // Convert the list to an array and return it
        return numbers.ToArray();
    }
    static void Main(string[] args)
    {
        int[] numbers; 
        numbers = ReadNumbersFromTextFile("D:\\Chillzone\\Job\\RWS\\Project1\\Project1\\inputs\\mytest.txt"); 
        List<int> bestSequence = new List<int>();
        int bestSum = 10000000;
        int shortestLength = 10000 + numbers.Length;
        //Find the sequence
        for (int i = 0; i < numbers.Length; i++)
        { 
            for (int j = i; j < numbers.Length; j++)
            {
                 
                int sum = 0;
                List<int> sequence = new List<int>();
                for (int k = i; k <= j; k++)
                {
                    sum += numbers[k];
                    sequence.Add(numbers[k]);
                }
                if (sum % 4 == 0 && sequence.Count <= shortestLength && sequence.Count >=2)
                {
                    if(sequence.Count == shortestLength && sum < bestSum || sequence.Count < shortestLength)
                    {
                        bestSum = sum;
                        bestSequence = sequence;
                        shortestLength = sequence.Count;
                    } 
                    
                }
            }
        }
        /*string fileName = "D:\\Chillzone\\Job\\RWS\\Project1\\Project1\\outputs\\output.txt";
        List<string> output = new List<string>();
        foreach (var number in bestSequence)
        {
            output.Add(string.Join(",", number));
        }
        File.WriteAllLines(fileName, output);
         */
        if(bestSequence.Count > 0)
        {
            foreach (int number in bestSequence)
            {
                Console.Write(number + " ");
            }

        }
        else
        {
            Console.WriteLine("No sequence found.");
        }
        Console.ReadLine();
    }
}