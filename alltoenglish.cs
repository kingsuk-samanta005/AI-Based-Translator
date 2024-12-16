using System;
using System.Collections.Generic;

namespace OfflineTranslator
{
    class Program
    {
        // Dictionaries for translations
        static Dictionary<string, string> spanishToEnglish = new Dictionary<string, string>
        {
            {"hola", "hello"},
            {"mundo", "world"},
            {"¿cómo estás?", "how are you"},
            {"buenos días", "good morning"},
            {"buenas noches", "good night"},
            {"gracias", "thank you"},
            {"por favor", "please"},
            {"sí", "yes"},
            {"no", "no"},
            {"adiós", "goodbye"}
        };

        static Dictionary<string, string> japaneseToEnglish = new Dictionary<string, string>
        {
            {"こんにちは", "hello"},
            {"世界", "world"},
            {"お元気ですか", "how are you"},
            {"おはようございます", "good morning"},
            {"おやすみなさい", "good night"},
            {"ありがとうございます", "thank you"},
            {"お願いします", "please"},
            {"はい", "yes"},
            {"いいえ", "no"},
            {"さようなら", "goodbye"}
        };

        static Dictionary<string, string> bengaliToEnglish = new Dictionary<string, string>
        {
            {"হ্যালো", "hello"},
            {"বিশ্ব", "world"},
            {"আপনি কেমন আছেন", "how are you"},
            {"সুপ্রভাত", "good morning"},
            {"শুভ রাত্রি", "good night"},
            {"ধন্যবাদ", "thank you"},
            {"অনুগ্রহ করে", "please"},
            {"হ্যাঁ", "yes"},
            {"না", "no"},
            {"বিদায়", "goodbye"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Offline Translator");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Translate between specific languages");
            Console.WriteLine("2. Translate all to English");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("Select Input Language: English, Spanish, Japanese, Bengali");
                string inputLanguage = Console.ReadLine().ToLower();

                Console.WriteLine("Select Output Language: English, Spanish, Japanese, Bengali");
                string outputLanguage = Console.ReadLine().ToLower();

                while (true)
                {
                    Console.Write($"{inputLanguage.ToUpper()}: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        Console.WriteLine("Exiting the translator. Goodbye!");
                        break;
                    }

                    string translation = Translate(input, inputLanguage, outputLanguage);

                    if (translation != null)
                    {
                        Console.WriteLine($"Translation ({outputLanguage.ToUpper()}): {translation}");
                    }
                    else
                    {
                        Console.WriteLine("Translation not found in the offline dictionary.");
                    }
                }
            }
            else if (option == "2")
            {
                while (true)
                {
                    Console.Write("Input (Spanish, Japanese, Bengali): ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        Console.WriteLine("Exiting the translator. Goodbye!");
                        break;
                    }

                    string translation = TranslateToEnglish(input);

                    if (translation != null)
                    {
                        Console.WriteLine($"Translation (ENGLISH): {translation}");
                    }
                    else
                    {
                        Console.WriteLine("Translation not found in the offline dictionary.");
                    }
                }
            }
        }

        static string TranslateToEnglish(string input)
        {
            if (spanishToEnglish.ContainsKey(input.ToLower()))
                return spanishToEnglish[input.ToLower()];

            if (japaneseToEnglish.ContainsKey(input))
                return japaneseToEnglish[input];

            if (bengaliToEnglish.ContainsKey(input))
                return bengaliToEnglish[input];

            return null;
        }

        static string Translate(string input, string inputLanguage, string outputLanguage)
        {
            Dictionary<string, string> sourceDictionary = null;
            Dictionary<string, string> targetDictionary = null;

            if (inputLanguage == "spanish")
                sourceDictionary = spanishToEnglish;
            else if (inputLanguage == "japanese")
                sourceDictionary = japaneseToEnglish;
            else if (inputLanguage == "bengali")
                sourceDictionary = bengaliToEnglish;

            if (sourceDictionary != null && outputLanguage == "english")
            {
                if (sourceDictionary.ContainsKey(input.ToLower()))
                {
                    return sourceDictionary[input.ToLower()];
                }
            }

            return null;
        }
    }
}
