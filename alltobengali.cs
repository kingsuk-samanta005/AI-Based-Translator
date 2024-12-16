using System;
using System.Collections.Generic;

namespace OfflineTranslator
{
    class Program
    {
        // Dictionaries for translations
        static Dictionary<string, string> englishToBengali = new Dictionary<string, string>
        {
            {"hello", "হ্যালো"},
            {"world", "বিশ্ব"},
            {"how are you", "আপনি কেমন আছেন"},
            {"good morning", "সুপ্রভাত"},
            {"good night", "শুভ রাত্রি"},
            {"thank you", "ধন্যবাদ"},
            {"please", "অনুগ্রহ করে"},
            {"yes", "হ্যাঁ"},
            {"no", "না"},
            {"goodbye", "বিদায়"}
        };

        static Dictionary<string, string> spanishToBengali = new Dictionary<string, string>
        {
            {"hola", "হ্যালো"},
            {"mundo", "বিশ্ব"},
            {"¿cómo estás?", "আপনি কেমন আছেন"},
            {"buenos días", "সুপ্রভাত"},
            {"buenas noches", "শুভ রাত্রি"},
            {"gracias", "ধন্যবাদ"},
            {"por favor", "অনুগ্রহ করে"},
            {"sí", "হ্যাঁ"},
            {"no", "না"},
            {"adiós", "বিদায়"}
        };

        static Dictionary<string, string> japaneseToBengali = new Dictionary<string, string>
        {
            {"こんにちは", "হ্যালো"},
            {"世界", "বিশ্ব"},
            {"お元気ですか", "আপনি কেমন আছেন"},
            {"おはようございます", "সুপ্রভাত"},
            {"おやすみなさい", "শুভ রাত্রি"},
            {"ありがとうございます", "ধন্যবাদ"},
            {"お願いします", "অনুগ্রহ করে"},
            {"はい", "হ্যাঁ"},
            {"いいえ", "না"},
            {"さようなら", "বিদায়"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Offline Translator");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Translate to English");
            Console.WriteLine("2. Translate to Bengali");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                TranslateTo("english");
            }
            else if (option == "2")
            {
                TranslateTo("bengali");
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
            if (targetLanguage == "english")
            {
                if (englishToBengali.ContainsKey(input.ToLower()))
                    return englishToBengali[input.ToLower()];
                if (spanishToBengali.ContainsKey(input))
                    return spanishToBengali[input];
                if (japaneseToBengali.ContainsKey(input))
                    return japaneseToBengali[input];
            }
            else if (targetLanguage == "bengali")
            {
                if (spanishToBengali.ContainsKey(input))
                    return spanishToBengali[input];
                if (japaneseToBengali.ContainsKey(input))
                    return japaneseToBengali[input];
                if (englishToBengali.ContainsKey(input.ToLower()))
                    return englishToBengali[input.ToLower()];
            }

            return null;
        }
    }
}
