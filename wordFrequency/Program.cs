using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = "Пример текста, в котором мы ищем наиболее часто встречающиеся слова. Этот текст будет использован в качестве примера.";

        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        var words = noPunctuationText.ToLower().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        var wordFrequency = words.GroupBy(word => word)
                                 .Select(group => new { Word = group.Key, Count = group.Count() })
                                 .OrderByDescending(x => x.Count)
                                 .Take(10);

        Console.WriteLine("10 самых часто встречающихся слов:");
        foreach (var word in wordFrequency)
        {
            Console.WriteLine($"{word.Word}: {word.Count}");
        }
    }
}