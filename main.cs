using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{

    const int TRIGRAM_COUNT_THRESHOLD = 20000;

    public static bool IsBinaryFile(string path)
    {
        HashSet<string> trigrams = new HashSet<string>();

        byte[] alltext = File.ReadAllBytes(path);
        for (int i = 0; i < alltext.Length - 3; i += 3)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(alltext[i]);
            sb.Append(alltext[i + 1]);
            sb.Append(alltext[i + 2]);
            string trigram = sb.ToString();
            trigrams.Add(trigram);
        }
        //Console.WriteLine($"{trigrams.Count}");
        return trigrams.Count > TRIGRAM_COUNT_THRESHOLD;
    }
    public static void Main(string[] args)
    {
        string cat = "cat123.png";
        string wap = "Tolstoy.txt";
        Console.WriteLine($"{cat}: {IsBinaryFile(cat)}");
        Console.WriteLine($"{wap}: {IsBinaryFile(wap)}");
    }
}