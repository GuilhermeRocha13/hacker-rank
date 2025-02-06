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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {

        s = s.Replace(" ", "");
        int tamanho = s.Length;

        int linhas = (int)Math.Floor(Math.Sqrt(tamanho));
        int colunas = (int)Math.Ceiling(Math.Sqrt(tamanho));

        if (linhas * colunas < tamanho)
            linhas++;

        List<string> stringEncriptada = new List<string>();

        for (int col = 0; col < colunas; col++)
        {
            string palavra = "";
            for (int linha = 0; linha < linhas; linha++)
            {
                int i = linha * colunas + col;
                if (i < tamanho)
                    palavra += s[i];
            }
            stringEncriptada.Add(palavra);
        }
        return string.Join(" ", stringEncriptada);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
