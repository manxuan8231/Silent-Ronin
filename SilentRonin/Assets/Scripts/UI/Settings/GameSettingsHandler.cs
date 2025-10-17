using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSettingsHandler : MonoBehaviour
{
    [Header("UI Texts")]
    public TMP_Text languageValue;
    public TMP_Text cameraShakeValue;
    public TMP_Text autoSaveValue;
    public TMP_Text showDamageValue;

    private string[] languages = { "English", "Vietnamese" };
    private int currentLanguage = 0;
    private bool cameraShake = true;
    private bool autoSave = true;
    private bool showDamage = true;

    //tham chieu
    public LanguageSwitcher languageSwitcher;
    void Start()
    {
        LoadSettings();
        UpdateUI();
        languageSwitcher = FindAnyObjectByType<LanguageSwitcher>();
    }

    // --- BUTTON FUNCTIONS ---
    public void ToggleLanguage()
    {
        currentLanguage++;
        if (currentLanguage >= languages.Length)
            currentLanguage = 0;

        //  GỌI script đổi ngôn ngữ thực tế
        if (languageSwitcher != null)
        {
            // dùng mã "en" / "vi" tương ứng
            string code = currentLanguage == 0 ? "en" : "vi";
            languageSwitcher.SetLocaleByCode(code);
        }
        // đổi text hiển thị
        UpdateUI();

        // lưu lại
        SaveSettings();

    }

    public void ToggleCameraShake()
    {
        cameraShake = !cameraShake;
        UpdateUI();
        SaveSettings();
    }

    public void ToggleAutoSave()
    {
        autoSave = !autoSave;
        UpdateUI();
        SaveSettings();
    }

    public void ToggleShowDamage()
    {
        showDamage = !showDamage;
        UpdateUI();
        SaveSettings();
    }

    public void ResetDefaults()
    {
        currentLanguage = 0;
        cameraShake = true;
        autoSave = true;
        showDamage = true;
        if (languageSwitcher != null)
        {
            languageSwitcher.SetLocaleByCode("en");
        }
        UpdateUI();
        SaveSettings();
       
    }

    // --- HELPER ---
    private void UpdateUI()
    {
        languageValue.text = languages[currentLanguage];
        //  GỌI script đổi ngôn ngữ thực tế
        if (languageSwitcher != null)
        {
            // dùng mã "en" / "vi" tương ứng
            string code = currentLanguage == 0 ? "en" : "vi";
            languageSwitcher.SetLocaleByCode(code);
            if(code == "en")
            {
               
                cameraShakeValue.text = cameraShake ? "On" : "Off";
                autoSaveValue.text = autoSave ? "On" : "Off";
                showDamageValue.text = showDamage ? "On" : "Off";
            }
            else if(code == "vi")
            {
                cameraShakeValue.text = cameraShake ? "Bật" : "Tắt";
                autoSaveValue.text = autoSave ? "Bật" : "Tắt";
                showDamageValue.text = showDamage ? "Bật" : "Tắt";
            }


               
        }
        
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("Language", currentLanguage);
        PlayerPrefs.SetInt("CameraShake", cameraShake ? 1 : 0);
        PlayerPrefs.SetInt("AutoSave", autoSave ? 1 : 0);
        PlayerPrefs.SetInt("ShowDamage", showDamage ? 1 : 0);
    }

    private void LoadSettings()
    {
        currentLanguage = PlayerPrefs.GetInt("Language", 0);
        cameraShake = PlayerPrefs.GetInt("CameraShake", 1) == 1;
        autoSave = PlayerPrefs.GetInt("AutoSave", 1) == 1;
        showDamage = PlayerPrefs.GetInt("ShowDamage", 1) == 1;
    }
}
