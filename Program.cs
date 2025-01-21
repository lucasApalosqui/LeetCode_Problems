using System;
using System.Collections.Generic;

public static class Languages
{
    private static List<string> _languages = new List<string>() { "C#", "Clojure", "Elm" };

    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return _languages;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        if (language != null) languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return (languages.Contains(language) ? true : false);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if(languages.Count == 0 || !languages.Contains("C#"))
            return false;

        if (languages[0] == "C#")
            return true;
        
        return (languages[1] == "C#" && languages.Count >= 2 && languages.Count <= 3) ? true : false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        if(!languages.Contains(language))
            return languages;

        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        foreach (string language in languages)
        {
            var languagecont = 0;
            for (int i = 0; i < languages.Count; i++)
            {
                if (languages[i] == language) languagecont++;


            }
            if (languagecont >= 2) return false;
        }
        return true;
    }
}
