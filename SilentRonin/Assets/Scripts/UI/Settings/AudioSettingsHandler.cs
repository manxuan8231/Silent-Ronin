using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettingsHandler : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("UI Texts")]
    public TMP_Text masterValueText;
    public TMP_Text musicValueText;
    public TMP_Text sfxValueText;
    public TMP_Text soundToggleText; // Hiển thị “On” hoặc “Off”

    private bool isSoundOn = true;

    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SfxKey = "SFXVolume";
    private const string SoundKey = "SoundEnabled";

    private void Start()
    {
        LoadSettings();
        ApplySettings();
        UpdateUI();
    }

    // --- Khi thay đổi slider ---
    public void OnSliderChanged()
    {
        ApplySettings();
        SaveSettings();
        UpdateUI(); // 👈 để cập nhật phần trăm ngay
    }

    // --- Khi bấm chữ On/Off ---
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        ApplySettings();
        SaveSettings();
        UpdateUI();
    }

    // --- Áp dụng âm lượng ---
    private void ApplySettings()
    {
        if (isSoundOn)
        {
            AudioListener.volume = masterSlider.value;
            // Nếu có mixer: MusicManager.Instance.SetVolume(musicSlider.value);
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }

    // --- Cập nhật UI ---
    private void UpdateUI()
    {
        // Hiển thị ON/OFF
        soundToggleText.text = isSoundOn ? "On" : "Off";

        // Hiển thị %
        masterValueText.text = Mathf.RoundToInt(masterSlider.value * 100f) + "%";
        musicValueText.text = Mathf.RoundToInt(musicSlider.value * 100f) + "%";
        sfxValueText.text = Mathf.RoundToInt(sfxSlider.value * 100f) + "%";
    }

    // --- Lưu ---
    private void SaveSettings()
    {
        PlayerPrefs.SetFloat(MasterKey, masterSlider.value);
        PlayerPrefs.SetFloat(MusicKey, musicSlider.value);
        PlayerPrefs.SetFloat(SfxKey, sfxSlider.value);
        PlayerPrefs.SetInt(SoundKey, isSoundOn ? 1 : 0);
    }

    // --- Tải ---
    private void LoadSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat(MasterKey, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(MusicKey, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SfxKey, 1f);
        isSoundOn = PlayerPrefs.GetInt(SoundKey, 1) == 1;
    }

    // --- Reset mặc định ---
    public void ResetDefaults()
    {
        masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;
        isSoundOn = true;

        ApplySettings();
        SaveSettings();
        UpdateUI();
    }
}
