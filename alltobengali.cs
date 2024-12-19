using UnityEngine;
using TMPro;  // Required for TextMeshPro components
using System.Collections.Generic;

public class BEN : MonoBehaviour
{
    // UI elements
    public TMP_InputField INPUT;  // TMP_InputField for word input
    public TextMeshProUGUI OUTPUT;  // TextMeshProUGUI for output display
    public TMP_Dropdown languageDropdown;  // Dropdown for language selection

    // Static dictionary for translations to Bengali
    static readonly Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>
    {
        { "bengali", new Dictionary<string, string>
            {
                {"হ্যালো", "হ্যালো"},
                {"বিশ্ব", "বিশ্ব"},
                {"আপনি কেমন আছেন", "আপনি কেমন আছেন"},
                {"সুপ্রভাত", "সুপ্রভাত"},
                {"শুভ রাত্রি", "শুভ রাত্রি"},
                {"ধন্যবাদ", "ধন্যবাদ"},
                {"অনুগ্রহ করে", "অনুগ্রহ করে"},
                {"হ্যাঁ", "হ্যাঁ"},
                {"না", "না"},
                {"বিদায়", "বিদায়"}
            }
        },
        { "spanish", new Dictionary<string, string>
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
            }
        },
        { "japanese", new Dictionary<string, string>
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
            }
        },
        { "english", new Dictionary<string, string>
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
            }
        }
    };

    // Translate method to convert from any language to Bengali
    static string TranslateToBengali(string input, string inputLanguage)
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

    // Public method to trigger translation to Bengali (for button click)
    public void BENGALI()
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

        // Perform the translation using the selected language to Bengali
        string translatedText = TranslateToBengali(input, inputLanguage);

        // Update the UI with the result
        OUTPUT.text = $"Bengali translation: {translatedText}";

        // Print the result to the Unity Console
        Debug.Log($"Bengali translation of '{input}' from {inputLanguage} is: {translatedText}");
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
