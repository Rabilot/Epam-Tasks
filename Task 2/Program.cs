using System;
using Task_2.Library.Text;
using Task_2.Library.Text.Parser;
using Task_2.Writer;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            /* Задача 1. Создать программу обработки текста учебника по программированию с использованием классов: Символ, Слово,
             Предложение, Знак препинания и др. (состав и иерархию классов продумать самостоятельно). Во всех задачах с формированием 
             текста заменять табуляции и последовательности пробелов одним пробелом.
             Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
             Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
             Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
             В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.*/
            
            IInfoWriter writer = new ConsoleWriter();
            string textString =
                "Зеленоватый сумрачный               аоздух, наполненный солнечным дымом и желтыми отсветами скал, струился над нами. " +
                "На солнце нельзя было теперь взглянуть: лохматыми ослепительными потоками оно лилось с вышины. " +
                "Дух Олимпиады — дух равенства и дружбы. Солнце село; но в лесу еще светло; воздух чист и прозрачен; " +
                "птицы заботливо лепечут; молодая трава блестит веселым блеском изумруда. Лес рубят - щепки летят?";
            IParser textParser = new TextParser();
            IText text = textParser.Parse(textString);
            writer.WriteLine(text.ToString());
            writer.WriteLine("\n");
            writer.WriteLine(text.GetSortedText().ToString());
            writer.WriteLine("Enter word length: ");
            int length = Convert.ToInt32(Console.ReadLine());
            foreach (var word in text.GetWordsWithoutRepeating(length))
            {
                writer.Write($"{word} ");
            }
            writer.WriteLine("\n");
            writer.WriteLine("Enter word length: ");
            length = Convert.ToInt32(Console.ReadLine());
            text.DeleteConsonantByLength(length);
            writer.WriteLine(text.ToString());
            writer.WriteLine("\n");
            writer.WriteLine("Enter number of sentence: ");
            int sentenceNumber = Convert.ToInt32(Console.ReadLine());
            writer.WriteLine("Enter word length: ");
            int wordsLength = Convert.ToInt32(Console.ReadLine());
            writer.WriteLine("Enter substring: ");
            string str = Console.ReadLine();
            text.ReplaceWordToString(sentenceNumber, wordsLength, str);
            writer.WriteLine(text.ToString());
        }
    }
}