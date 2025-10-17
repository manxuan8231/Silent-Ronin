using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{

    [Header("MainPanel")]
    public GameObject paneBackGroundMain;
    public GameObject panelOption; // Panel cài đặt
    public GameObject panelQuit;// Panel xác nhận thoát game
    

    [Header("Thong so")]
    public float delayShowPanelOption = 0.2f;
   

    [Header("Tab Panel Option")]
    public GameObject optionContainer;// Chứa các tab trong panel option
    public GameObject panelGameSetting;
    public GameObject panelAudioSetting;
    public GameObject panelVideoSetting;
    public GameObject panelKeyBoardSetting;

    // Gọi khi bấm "Start Game"---------------------
    public void OnStartGame()
    {
        SceneManager.LoadScene("Level_01"); 
    }


    // Gọi khi bấm "Achievements"--------------------
    public void OnAchievements()
    {
        Debug.Log("Achievements opened");
        // TODO: mở panel thành tựu
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
    //Option----
    public IEnumerator DelayShowPanelOption()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelOption.SetActive(true);
        paneBackGroundMain.SetActive(false);
    }
    public IEnumerator DelayOffPanelOption()
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelOption.SetActive(false);
        paneBackGroundMain.SetActive(true);
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
    //panel quit----
    public IEnumerator DelayShowPanelQuit() 
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        panelQuit.SetActive(true);
        paneBackGroundMain.SetActive(false);

    }
    public IEnumerator DelayOffPanelQuit() 
    {
        yield return new WaitForSeconds(delayShowPanelOption);
        paneBackGroundMain.SetActive(true);
        panelQuit.SetActive(false);

    }

    private void Start()
    {
        paneBackGroundMain.SetActive(true);
        panelOption.SetActive(false);
        panelQuit.SetActive(false);
        panelGameSetting.SetActive(false);
        panelAudioSetting.SetActive(false);
        optionContainer.SetActive(true);
    }
}
