using System;
using Task_2.Library.Text;
using Task_2.Library.Text.Parser;
using Task_2.Writer;
using System.Configuration;
using Task_2.Reader;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = ConfigurationManager.AppSettings;
            IFileReader reader = new TxtFileReader();
            string textString;
            try
            {
                textString = reader.Read(config.Get("inputFile"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            IInfoWriter fileWriter;
            try
            {
                fileWriter = new FileWriter(config.Get("outputFile"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            IInfoWriter consoleWriter = new ConsoleWriter();
            IParser textParser = new TextParser();
            IText text;
            try
            {
                text = textParser.Parse(textString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Parsing error: {e.Message}");
                return;
            }
            fileWriter.WriteLine(text.ToString());
            fileWriter.WriteLine("\nTask 1.1:");
            fileWriter.WriteLine(text.GetSortedText().ToString());
            consoleWriter.WriteLine($"{text}\n");
            consoleWriter.WriteLine("Task 1.2: Во всех вопросительных предложениях текста найти и напечатать " +
                                    "без повторений слова заданной длины.");
            uint length;
            try
            {
                consoleWriter.WriteLine("Enter word length: ");
                length = Convert.ToUInt32(Console.ReadLine());
                fileWriter.WriteLine("\nTask 1.2:");
                foreach (var word in text.GetWords(length, "?"))
                {
                    fileWriter.Write($"{word} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            consoleWriter.WriteLine("Task 1.3: Из текста удалить все слова заданной длины, начинающиеся на согласную букву.");
            try
            {
                consoleWriter.WriteLine("Enter word length: ");
                length = Convert.ToUInt32(Console.ReadLine());
                text.DeleteConsonantByLength(length);
                fileWriter.WriteLine("\nTask 1.3:");
                fileWriter.WriteLine(text.ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            consoleWriter.WriteLine("Task 1.4: В некотором предложении текста слова заданной длины заменить " +
                                    "указанной подстрокой, длина которой может не совпадать с длиной слова.");
            try
            {
                consoleWriter.WriteLine("Enter number of sentence: ");
                int sentenceNumber = Convert.ToInt32(Console.ReadLine());
                consoleWriter.WriteLine("Enter word length: ");
                uint wordsLength = Convert.ToUInt32(Console.ReadLine());
                consoleWriter.WriteLine("Enter substring: ");
                string str = Console.ReadLine();
                text.ReplaceWordToString(sentenceNumber, wordsLength, str);
                fileWriter.WriteLine("\nTask 1.4:");
                fileWriter.WriteLine(text.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}