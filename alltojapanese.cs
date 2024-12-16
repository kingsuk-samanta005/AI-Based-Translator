using System;
using System.Collections.Generic;

namespace OfflineTranslator
{
    class Program
    {
        // Dictionaries for translations
        static Dictionary<string, string> englishToJapanese = new Dictionary<string, string>
        {
            {"hello", "こんにちは"},
            {"world", "世界"},
            {"how are you", "お元気ですか"},
            {"good morning", "おはようございます"},
            {"good night", "おやすみなさい"},
            {"thank you", "ありがとうございます"},
            {"please", "お願いします"},
            {"yes", "はい"},
            {"no", "いいえ"},
            {"goodbye", "さようなら"}
        };

        static Dictionary<string, string> spanishToJapanese = new Dictionary<string, string>
        {
            {"hola", "こんにちは"},
            {"mundo", "世界"},
            {"¿cómo estás?", "お元気ですか"},
            {"buenos días", "おはようございます"},
            {"buenas noches", "おやすみなさい"},
            {"gracias", "ありがとうございます"},
            {"por favor", "お願いします"},
            {"sí", "はい"},
            {"no", "いいえ"},
            {"adiós", "さようなら"}
        };

        static Dictionary<string, string> bengaliToJapanese = new Dictionary<string, string>
        {
            {"হ্যালো", "こんにちは"},
            {"বিশ্ব", "世界"},
            {"আপনি কেমন আছেন", "お元気ですか"},
            {"সুপ্রভাত", "おはようございます"},
            {"শুভ রাত্রি", "おやすみなさい"},
            {"ধন্যবাদ", "ありがとうございます"},
            {"অনুগ্রহ করে", "お願いします"},
            {"হ্যাঁ", "はい"},
            {"না", "いいえ"},
            {"বিদায়", "さようなら"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Offline Translator");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Translate to English");
            Console.WriteLine("2. Translate to Japanese");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                TranslateTo("english");
            }
            else if (option == "2")
            {
                TranslateTo("japanese");
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
                if (englishToJapanese.ContainsKey(input.ToLower()))
                    return englishToJapanese[input.ToLower()];
                if (spanishToJapanese.ContainsKey(input))
                    return spanishToJapanese[input];
                if (bengaliToJapanese.ContainsKey(input))
                    return bengaliToJapanese[input];
            }
            else if (targetLanguage == "japanese")
            {
                if (spanishToJapanese.ContainsKey(input))
                    return spanishToJapanese[input];
                if (bengaliToJapanese.ContainsKey(input))
                    return bengaliToJapanese[input];
                if (englishToJapanese.ContainsKey(input.ToLower()))
                    return englishToJapanese[input.ToLower()];
            }

            return null;
        }
    }
}
