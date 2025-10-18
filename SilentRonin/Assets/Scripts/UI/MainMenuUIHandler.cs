using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{

    [Header("MainPanel")]
    public GameObject paneMainMenu;
    public GameObject panelSaveSlots;
    public GameObject panelOption; // Panel cài đặt
    public GameObject panelAchievements; 
    public GameObject panelQuit;// Panel xác nhận thoát game
    

    [Header("Thong so")]
    public float delayShowPanelOption = 0.2f;
    public string sceneName;


    [Header("Tab Panel Option")]
    public GameObject optionContainer;// Chứa các tab trong panel option
    public GameObject panelGameSetting;
    public GameObject panelAudioSetting;
    public GameObject panelVideoSetting;
    public GameObject panelKeyBoardSetting;

    // Gọi khi bấm "Start Game"---------------------
    public void OnStartGame()
    {
        StartCoroutine(DelayStartGame());
    }

    // Gọi khi bấm "Start Game"--------------------
    public void OpenPanelSaveSlots()
    {
       StartCoroutine(DelayShowPanelSaveSlots());
    }
    public void ClosePanelSaveSlots()
    {
       StartCoroutine(DelayBackPanelSaveSlots());
    }
    // Gọi khi bấm "Achievements"--------------------
    public void OnAchievements()
    {
        StartCoroutine(DelayShowPanelAchievements());
    }
    public void OffAchievements()
    {
       StartCoroutine(DelayOffPanelAchievements());
    }

    // Gọi khi bấm "Option"-----------------------
    public void OpenPanelOption()
    {
        StartCoroutine(DelayShowPanelOption());
    }
    public void OffPanelOption()
    {
        StartCoroutine(DelayOffPanelOption());
    }
    //tab panel option
    public void OpenPanelGameSetting()
    {
      StartCoroutine(DelayOpenPanelGameSetting());
    }
    public void BackPanelGameSetting()
    {
        StartCoroutine(DelayBackPanelGameSetting());
    }

    public void OpenPanelAudioSetting()
    {
        StartCoroutine(DelayOpenPanelAudioSetting());
    }
    public void BackPanelAudioSetting()
    {
        StartCoroutine(DelayBackPanelAudioSetting());
    }

    public void OpenPanelVideoSetting()
    {
        StartCoroutine(DelayOpenPanelVideoSetting());
    } 
    public void BackPanelVideoSetting()
    {
        StartCoroutine(DelayBackPanelVideoSetting());
    }

    public void OpenPanelKeyboardSetting()
    {
        StartCoroutine(DelayOpenPanelKeyboard());
    }
    public void BackPanelKeyboardSetting()
    {
        StartCoroutine(DelayBackPanelKeyboard());
    }

    // Gọi khi bấm "Quit Game"------------------
    public void OpenPanelQuitGame()
    {
        StartCoroutine(DelayShowPanelQuit());
    } 
    public void YesQuitGame()
    {
        Application.Quit();
       
    }
    public void NoQuitGame()
    {
       StartCoroutine(DelayOffPanelQuit());

    }

    //-----------IEnumerator-------------
    //start game
    public IEnumerator DelayStartGame()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        SceneManager.LoadScene(sceneName);
    }

    //SaveSlots-----
    public IEnumerator DelayShowPanelSaveSlots()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        paneMainMenu.SetActive(false);
        panelSaveSlots.SetActive(true);
    }
    public IEnumerator DelayBackPanelSaveSlots()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        paneMainMenu.SetActive(true);
        panelSaveSlots.SetActive(false);
    }

    //Option----
    public IEnumerator DelayShowPanelOption()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelOption.SetActive(true);
        paneMainMenu.SetActive(false);
    }
    public IEnumerator DelayOffPanelOption()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelOption.SetActive(false);
        paneMainMenu.SetActive(true);
    }
    //tab
    public IEnumerator DelayOpenPanelGameSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelGameSetting.SetActive(true);
        optionContainer.SetActive(false);
    } 
    public IEnumerator DelayBackPanelGameSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelGameSetting.SetActive(false);
        optionContainer.SetActive(true);
    }

    public IEnumerator DelayOpenPanelAudioSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelAudioSetting.SetActive(true);
        optionContainer.SetActive(false);
    }
    public IEnumerator DelayBackPanelAudioSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelAudioSetting.SetActive(false);
        optionContainer.SetActive(true);
    }

    public IEnumerator DelayOpenPanelVideoSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelVideoSetting.SetActive(true);
        optionContainer.SetActive(false);
    }
    public IEnumerator DelayBackPanelVideoSetting()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelVideoSetting.SetActive(false);
        optionContainer.SetActive(true);
    }

    public IEnumerator DelayOpenPanelKeyboard()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelKeyBoardSetting.SetActive(true);
        optionContainer.SetActive(false);
    }
    public IEnumerator DelayBackPanelKeyboard()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelKeyBoardSetting.SetActive(false);
        optionContainer.SetActive(true);
    }

    //panel Achievements
    public IEnumerator DelayShowPanelAchievements()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelAchievements.SetActive(true);
        paneMainMenu.SetActive(false);
    }
    public IEnumerator DelayOffPanelAchievements()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        paneMainMenu.SetActive(true);
        panelAchievements.SetActive(false);
    }

    //panel quit----
    public IEnumerator DelayShowPanelQuit() 
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelQuit.SetActive(true);
        paneMainMenu.SetActive(false);

    }
    public IEnumerator DelayOffPanelQuit() 
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        paneMainMenu.SetActive(true);
        panelQuit.SetActive(false);

    }

    private void Start()
    {
        paneMainMenu.SetActive(true);
        panelAchievements.SetActive(false);
        panelOption.SetActive(false);
        panelQuit.SetActive(false);
        panelGameSetting.SetActive(false);
        panelAudioSetting.SetActive(false);
        panelVideoSetting.SetActive(false);
        panelKeyBoardSetting.SetActive(false);
        panelSaveSlots.SetActive(false);
        optionContainer.SetActive(true);
    }
}
