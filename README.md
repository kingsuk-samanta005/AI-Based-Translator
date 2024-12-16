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
 ascond set of code
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
third set of code 
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
last set of code
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
