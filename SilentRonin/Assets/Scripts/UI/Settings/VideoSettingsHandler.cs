using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsHandler : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Text fullscreenText;
    public TMP_Text vsyncText;
    public Slider brightnessSlider;
    public TMP_Text brightnessValueText;

    private bool isFullscreen = true;
    private bool isVsync = true;
    private Resolution[] resolutions;

    public TMP_Text fpsText; // hiển thị FPS hiện tại
    private int[] fpsOptions = { 30, 60, 120, 9999 }; // 9999 = không giới hạn
    private int currentFpsIndex = 1; // mặc định 60

    private void Start()
    {
        LoadResolutions();
        LoadSettings();
        ApplySettings();
        UpdateUI();
    }

    private void LoadResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();
        int currentIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height}";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                currentIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void OnResolutionChanged()
    {
        Resolution res = resolutions[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, isFullscreen);
        SaveSettings();
    }
    public void ToggleFPS()
    {
        currentFpsIndex++;
        if (currentFpsIndex >= fpsOptions.Length)
            currentFpsIndex = 0;

        int target = fpsOptions[currentFpsIndex];
        Application.targetFrameRate = target == 9999 ? -1 : target;

        SaveSettings();
        UpdateUI();
    }

    public void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        SaveSettings();
        UpdateUI();
    }

    public void ToggleVsync()
    {
        isVsync = !isVsync;
        QualitySettings.vSyncCount = isVsync ? 1 : 0;
        SaveSettings();
        UpdateUI();
    }

    public void OnBrightnessChanged()
    {
        float value = brightnessSlider.value;
        // Mô phỏng ánh sáng — bạn có thể thay bằng post-processing nếu có
        RenderSettings.ambientLight = Color.white * value;
        brightnessValueText.text = Mathf.RoundToInt(value * 100f) + "%";
        SaveSettings();
    }

    public void ResetDefaults()
    {
        isFullscreen = true;
        isVsync = true;
        brightnessSlider.value = 1f;
        resolutionDropdown.value = 0;
        currentFpsIndex = 1; // 60 FPS
        ApplySettings();
        SaveSettings();
        UpdateUI();
    }

    private void ApplySettings()
    {
        Screen.fullScreen = isFullscreen;
        QualitySettings.vSyncCount = isVsync ? 1 : 0;
        RenderSettings.ambientLight = Color.white * brightnessSlider.value;
    }

    private void UpdateUI()
    {
        fullscreenText.text = isFullscreen ? "On" : "Off";
        vsyncText.text = isVsync ? "On" : "Off";
        brightnessValueText.text = Mathf.RoundToInt(brightnessSlider.value * 100f) + "%";
        string fpsLabel = fpsOptions[currentFpsIndex] == 9999 ? "Unlimited" : fpsOptions[currentFpsIndex] + "FPS";
        fpsText.text = fpsLabel;

    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.SetInt("VSync", isVsync ? 1 : 0);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("FPSIndex", currentFpsIndex);

    }

    private void LoadSettings()
    {
        isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        isVsync = PlayerPrefs.GetInt("VSync", 1) == 1;
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1f);
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", 0);
        currentFpsIndex = PlayerPrefs.GetInt("FPSIndex", 1);
        Application.targetFrameRate = fpsOptions[currentFpsIndex] == 9999 ? -1 : fpsOptions[currentFpsIndex];

    }
}
