
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Helper {
    
    private static Random rng = new Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static void Log(List<string> lines,int tabs,string fileName) {
        File.WriteAllLines(fileName, lines);
    }

}