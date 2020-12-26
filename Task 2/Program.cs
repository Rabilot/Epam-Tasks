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
            IInfoWriter fileWriter = new FileWriter(config.Get("outputFile"));
            IInfoWriter consoleWriter = new ConsoleWriter();
            IFileReader reader = new TxtFileReader();
            var textString = reader.Read(config.Get("inputFile"));
            IParser textParser = new TextParser();
            IText text = textParser.Parse(textString);
            fileWriter.WriteLine(text.ToString());
            fileWriter.WriteLine("\nTask 1.1:");
            fileWriter.WriteLine(text.GetSortedText().ToString());
            consoleWriter.WriteLine($"{text}\n");
            consoleWriter.WriteLine("Task 1.2: Во всех вопросительных предложениях текста найти и напечатать " +
                                    "без повторений слова заданной длины.");
            consoleWriter.WriteLine("Enter word length: ");
            int length = Convert.ToInt32(Console.ReadLine());
            fileWriter.WriteLine("\nTask 1.2:");
            foreach (var word in text.GetWords(length, "?"))
            {
                fileWriter.Write($"{word} ");
            }
            consoleWriter.WriteLine("Task 1.3: Из текста удалить все слова заданной длины, начинающиеся на согласную букву.");
            consoleWriter.WriteLine("Enter word length: ");
            length = Convert.ToInt32(Console.ReadLine());
            text.DeleteConsonantByLength(length);
            fileWriter.WriteLine("\nTask 1.3:");
            fileWriter.WriteLine(text.ToString());
            consoleWriter.WriteLine("Task 1.4: В некотором предложении текста слова заданной длины заменить " +
                                    "указанной подстрокой, длина которой может не совпадать с длиной слова.");
            consoleWriter.WriteLine("Enter number of sentence: ");
            int sentenceNumber = Convert.ToInt32(Console.ReadLine());
            consoleWriter.WriteLine("Enter word length: ");
            int wordsLength = Convert.ToInt32(Console.ReadLine());
            consoleWriter.WriteLine("Enter substring: ");
            string str = Console.ReadLine();
            text.ReplaceWordToString(sentenceNumber, wordsLength, str);
            fileWriter.WriteLine("\nTask 1.4:");
            fileWriter.WriteLine(text.ToString());
        }
    }
}