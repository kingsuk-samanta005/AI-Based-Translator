using UnityEngine;
using TMPro;  // Required for TextMeshPro components
using System.Collections.Generic;

public class SPA : MonoBehaviour
{
    // UI elements
    public TMP_InputField INPUT;  // TMP_InputField for word input
    public TextMeshProUGUI OUTPUT;  // TextMeshProUGUI for output display
    public TMP_Dropdown languageDropdown;  // Dropdown for language selection

    // Static dictionary for translations to Spanish
    static readonly Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>
    {
        { "bengali", new Dictionary<string, string>
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
            }
        },
        { "spanish", new Dictionary<string, string>
            {
                {"hola", "hola"},
                {"mundo", "mundo"},
                {"¿cómo estás?", "¿cómo estás?"},
                {"buenos días", "buenos días"},
                {"buenas noches", "buenas noches"},
                {"gracias", "gracias"},
                {"por favor", "por favor"},
                {"sí", "sí"},
                {"no", "no"},
                {"adiós", "adiós"}
            }
        },
        { "japanese", new Dictionary<string, string>
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
            }
        },
        { "english", new Dictionary<string, string>
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
            }
        }
    };

    // Translate method to convert from any language to Spanish
    static string TranslateToSpanish(string input, string inputLanguage)
    {
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(inputLanguage))
        {
            return "¡Entrada no válida!";
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

        return "¡Traducción no encontrada!";
    }

    // Public method to trigger translation to Spanish (for button click)
    public void SPANISH()
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
            OUTPUT.text = "Por favor, ingrese una palabra para traducir.";
            Debug.LogWarning("No input provided for translation.");
            return;
        }

        // Get the selected language from the dropdown and ensure it's lowercase and trimmed
        string inputLanguage = languageDropdown.options[languageDropdown.value].text.Trim().ToLower();

        // Perform the translation using the selected language to Spanish
        string translatedText = TranslateToSpanish(input, inputLanguage);

        // Update the UI with the result
        OUTPUT.text = $"Traducción al español: {translatedText}";

        // Print the result to the Unity Console
        Debug.Log($"Traducción al español de '{input}' desde {inputLanguage} es: {translatedText}");
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
