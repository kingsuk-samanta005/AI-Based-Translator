using System;
using System.Collections.Generic;

namespace OfflineTranslator
{
    class Program
    {
        // Dictionaries for translations
        static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>
        {
            {"hello", "hola"},
            {"world", "mundo"},
            {"how are you", "¿cómo estás?"},
            {"good morning", "buenos días"},
            {"good night", "buenas noches"},
            {"thank you", "gracias"},
            {"please", "por favor"},
            {"yes", "sí"},
            {"no", "no"},
            {"goodbye", "adiós"}
        };

        static Dictionary<string, string> japaneseToSpanish = new Dictionary<string, string>
        {
            {"こんにちは", "hola"},
            {"世界", "mundo"},
            {"お元気ですか", "¿cómo estás?"},
            {"おはようございます", "buenos días"},
            {"おやすみなさい", "buenas noches"},
            {"ありがとうございます", "gracias"},
            {"お願いします", "por favor"},
            {"はい", "sí"},
            {"いいえ", "no"},
            {"さようなら", "adiós"}
        };

        static Dictionary<string, string> bengaliToSpanish = new Dictionary<string, string>
        {
            {"হ্যালো", "hola"},
            {"বিশ্ব", "mundo"},
            {"আপনি কেমন আছেন", "¿cómo estás?"},
            {"সুপ্রভাত", "buenos días"},
            {"শুভ রাত্রি", "buenas noches"},
            {"ধন্যবাদ", "gracias"},
            {"অনুগ্রহ করে", "por favor"},
            {"হ্যাঁ", "sí"},
            {"না", "no"},
            {"বিদায়", "adiós"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Offline Translator");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Translate to English");
            Console.WriteLine("2. Translate to Spanish");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                TranslateTo("english");
            }
            else if (option == "2")
            {
                TranslateTo("spanish");
            }
        }

        static void TranslateTo(string targetLanguage)
        {
            while (true)
            {
                Console.WriteLine("Enter input (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting the translator. Goodbye!");
                    break;
                }

                string translation = Translate(input, targetLanguage);

                if (translation != null)
                {
                    Console.WriteLine($"Translation ({targetLanguage.ToUpper()}): {translation}");
                }
                else
                {
                    Console.WriteLine("Translation not found in the offline dictionary.");
                }
            }
        }

        static string Translate(string input, string targetLanguage)
        {
            Dictionary<string, string> sourceDictionary = null;

            if (targetLanguage == "english")
            {
                if (englishToSpanish.ContainsKey(input.ToLower()))
                    return englishToSpanish[input.ToLower()];
                if (japaneseToSpanish.ContainsKey(input))
                    return japaneseToSpanish[input];
                if (bengaliToSpanish.ContainsKey(input))
                    return bengaliToSpanish[input];
            }
            else if (targetLanguage == "spanish")
            {
                if (japaneseToSpanish.ContainsKey(input))
                    return japaneseToSpanish[input];
                if (bengaliToSpanish.ContainsKey(input))
                    return bengaliToSpanish[input];
                if (englishToSpanish.ContainsKey(input.ToLower()))
                    return englishToSpanish[input.ToLower()];
            }

            return null;
        }
    }
}
