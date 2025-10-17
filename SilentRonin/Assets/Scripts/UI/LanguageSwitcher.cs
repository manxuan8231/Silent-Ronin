using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class LanguageSwitcher : MonoBehaviour
{
    const string PREF_KEY = "preferred_locale"; // "en" hoặc "vi"
    bool isChanging = false;

    void Start()
    {
        // Áp ngôn ngữ đã lưu càng sớm càng tốt (ở Boot scene/ MainMenu)
        var code = PlayerPrefs.GetString(PREF_KEY, "en");
        SetLocaleByCode(code, save: false);
    }

    public void ToggleLanguage() // Gán vào Button_Value "Language"
    {
        // Đổi qua lại en <-> vi
        string current = LocalizationSettings.SelectedLocale.Identifier.Code; // "en" hoặc "vi"
        string next = current == "en" ? "vi" : "en";
        SetLocaleByCode(next);
    }

    public void SetLocaleByCode(string code, bool save = true)
    {
        if (isChanging) return;
        StartCoroutine(SetLocale(code, save));
    }

    IEnumerator SetLocale(string code, bool save)
    {
        isChanging = true;
        // Đảm bảo hệ thống đã init
        yield return LocalizationSettings.InitializationOperation;

        var locales = LocalizationSettings.AvailableLocales.Locales;
        Locale target = locales.Find(l => l.Identifier.Code == code);
        if (target != null)
        {
            LocalizationSettings.SelectedLocale = target; // đổi ngôn ngữ
            if (save) PlayerPrefs.SetString(PREF_KEY, code);
        }
        isChanging = false;
    }
}
