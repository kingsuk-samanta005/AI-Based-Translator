using UnityEngine;
using TMPro;  // Required for TextMeshPro components
using System.Collections.Generic;

public class ENG : MonoBehaviour
{
    // UI elements
    public TMP_InputField INPUT;  // TMP_InputField for word input
    public TextMeshProUGUI OUTPUT;  // TextMeshProUGUI for output display
    public TMP_Dropdown languageDropdown;  // Dropdown for language selection

    // Static dictionary for translations to English
    static readonly Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>
    {
        { "bengali", new Dictionary<string, string>
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
            }
        },
        { "spanish", new Dictionary<string, string>
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
            }
        },
        { "japanese", new Dictionary<string, string>
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
            }
        },
        { "english", new Dictionary<string, string>
            {
                {"hello", "hello"},
                {"world", "world"},
                {"how are you", "how are you"},
                {"good morning", "good morning"},
                {"good night", "good night"},
                {"thank you", "thank you"},
                {"please", "please"},
                {"yes", "yes"},
                {"no", "no"},
                {"goodbye", "goodbye"}
            }
        }
    };

    // Translate method to convert from any language to English
    static string TranslateToEnglish(string input, string inputLanguage)
    {
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(inputLanguage))
        {
            return "Invalid input!";
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

        return "Translation not found!";
    }

    // Public method to trigger translation (for button click)
    public void ENGLISH()
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
            OUTPUT.text = "Please enter a word to translate.";
            Debug.LogWarning("No input provided for translation.");
            return;
        }

        // Get the selected language from the dropdown and ensure it's lowercase and trimmed
        string inputLanguage = languageDropdown.options[languageDropdown.value].text.Trim().ToLower();

        // Perform the translation using the selected language
        string translatedText = TranslateToEnglish(input, inputLanguage);

        // Update the UI with the result
        OUTPUT.text = $"English translation: {translatedText}";

        // Print the result to the Unity Console
        Debug.Log($"English translation of '{input}' from {inputLanguage} is: {translatedText}");
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
