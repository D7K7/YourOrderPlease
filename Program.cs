using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public static class Kata
{
 public static string Order(string words)
    {
        if (string.IsNullOrWhiteSpace(words)) return ""; 

        List<string> wordsInString = new List<string>();
        string[] separators = new string[] {",", ".", "!", "\'", " ", "\'s"};

        foreach (string word in words.Split(separators, StringSplitOptions.RemoveEmptyEntries))
        {
            wordsInString.Add(word);
        }

        wordsInString.Sort((a, b) => ExtractNumber(a).CompareTo(ExtractNumber(b)));

        StringBuilder newString = new StringBuilder("", words.Length);

        foreach (var word in wordsInString)
        {
            newString.Append(word + " ");
        }

        return newString.ToString().Trim();
    }

    private static int ExtractNumber(string word)
    {
        var match = Regex.Match(word, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }    
  }
