using UnityEngine;
using TMPro;  // Required for TextMeshPro components
using System.Collections.Generic;

public class JAP : MonoBehaviour
{
    // UI elements
    public TMP_InputField INPUT;  // TMP_InputField for word input
    public TextMeshProUGUI OUTPUT;  // TextMeshProUGUI for output display
    public TMP_Dropdown languageDropdown;  // Dropdown for language selection

    // Static dictionary for translations to Japanese
    static readonly Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>
    {
        { "bengali", new Dictionary<string, string>
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
            }
        },
        { "spanish", new Dictionary<string, string>
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
            }
        },
        { "japanese", new Dictionary<string, string>
            {
                {"こんにちは", "こんにちは"},
                {"世界", "世界"},
                {"お元気ですか", "お元気ですか"},
                {"おはようございます", "おはようございます"},
                {"おやすみなさい", "おやすみなさい"},
                {"ありがとうございます", "ありがとうございます"},
                {"お願いします", "お願いします"},
                {"はい", "はい"},
                {"いいえ", "いいえ"},
                {"さようなら", "さようなら"}
            }
        },
        { "english", new Dictionary<string, string>
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
            }
        }
    };

    // Translate method to convert from any language to Japanese
    static string TranslateToJapanese(string input, string inputLanguage)
    {
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(inputLanguage))
        {
            return "無効な入力！";
        }

        inputLanguage = inputLanguage.Trim().ToLower();  // Ensure no extra spaces and lowercase

        // Ensure we are processing the input correctly by trimming and lowercasing
        input = input.Trim().ToLower();  // Ensure no extra spaces and lowercase

        // Check if language dictionary exists
        if (translations.ContainsKey(inputLanguage))
        {
            var sourceDictionary = translations[inputLanguage];

            // Check if the word exists in the dictionary
            if (sourceDictionary.ContainsKey(input))
            {
                return sourceDictionary[input];
            }
        }

        return "翻訳が見つかりません！";
    }

    // Public method to trigger translation to Japanese (for button click)
    public void JAPANESE()
    {
        // Ensure UI elements are assigned
        if (INPUT == null || OUTPUT == null || languageDropdown == null)
        {
            Debug.LogError("UI elements are not assigned in the Unity Editor.");
            return;
        }

        // Get input word from the TMP_InputField
        string input = INPUT.text;

        if (string.IsNullOrWhiteSpace(input))
        {
            OUTPUT.text = "翻訳する単語を入力してください。";
            Debug.LogWarning("No input provided for translation.");
            return;
        }

        // Get the selected language from the dropdown and ensure it's lowercase and trimmed
        string inputLanguage = languageDropdown.options[languageDropdown.value].text.Trim().ToLower();

        // Perform the translation using the selected language to Japanese
        string translatedText = TranslateToJapanese(input, inputLanguage);

        // Update the UI with the result
        OUTPUT.text = $"日本語訳: {translatedText}";

        // Print the result to the Unity Console
        Debug.Log($"日本語訳 '{input}' から {inputLanguage} は: {translatedText}");
    }

    private void Awake()
    {
        // Log a warning if UI components are not assigned
        if (INPUT == null)
        {
            Debug.LogWarning("INPUT is not assigned. Please assign it in the Unity Editor.");
        }
        if (OUTPUT == null)
        {
            Debug.LogWarning("OUTPUT is not assigned. Please assign it in the Unity Editor.");
        }
        if (languageDropdown == null)
        {
            Debug.LogWarning("Language Dropdown is not assigned. Please assign it in the Unity Editor.");
        }

        // Populate the language dropdown dynamically if you prefer not to set this in the Unity inspector
        if (languageDropdown != null)
        {
            languageDropdown.ClearOptions();
            languageDropdown.AddOptions(new List<string> { "Bengali", "Spanish", "Japanese", "English" });
        }
    }
}
