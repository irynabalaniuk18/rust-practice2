// https://www.hackerrank.com/challenges/migratory-birds/problem
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     * 1. INTEGER n
     * 2. INTEGER_ARRAY ar
     */
    public static int sockMerchant(int n, List<int> ar)
    {
        // Створюємо множину для відстеження одиночних шкарпеток
        HashSet<int> colors = new HashSet<int>();
        int pairs = 0;

        foreach (int sock in ar)
        {
            // Якщо колір вже є у множині — ми знайшли пару
            if (colors.Contains(sock))
            {
                pairs++;
                colors.Remove(sock); // Видаляємо, щоб почати пошук нової пари цього кольору
            }
            else
            {
                // Якщо немає — додаємо шкарпетку в очікуванні пари
                colors.Add(sock);
            }
        }

        return pairs;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Читання шляху для виводу (стандарт для HackerRank)
        string outputPath = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        TextWriter textWriter = new StreamWriter(outputPath ?? Console.Out.ToString(), true);

        // Зчитуємо кількість шкарпеток
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        // Зчитуємо масив кольорів
        List<int> ar = Console.ReadLine().TrimEnd().Split(' ')
            .ToList()
            .Select(arTemp => Convert.ToInt32(arTemp))
            .ToList();

        // Отримуємо результат з нашої функції
        int result = Result.sockMerchant(n, ar);

        // Записуємо результат
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
