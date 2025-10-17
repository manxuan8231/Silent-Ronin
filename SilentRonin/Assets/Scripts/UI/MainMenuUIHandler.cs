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
    public float delayShowPanelOption = 0.5f;
    public float delayOffPanelOption = 0.5f; 
    public float delayShowPanelGameSetting = 0.5f;
    public float delayBackPanelGameSetting = 0.5f;
    public float delayShowPanelQuit = 0.5f; // Thời gian chờ hiện panel xác nhận thoát game
    public float delayOffPanelQuit = 0.5f;

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
        yield return new WaitForSeconds(delayOffPanelOption);
        panelOption.SetActive(false);
        paneBackGroundMain.SetActive(true);
    }
    //tab
    public IEnumerator DelayOpenPanelGameSetting()
    {
        yield return new WaitForSeconds(delayShowPanelGameSetting);
        panelGameSetting.SetActive(true);
        optionContainer.SetActive(false);
    } 
    public IEnumerator DelayBackPanelGameSetting()
    {
        yield return new WaitForSeconds(delayBackPanelGameSetting);
        panelGameSetting.SetActive(false);
        optionContainer.SetActive(true);
    }

    //panel quit----
    public IEnumerator DelayShowPanelQuit() 
    {
        yield return new WaitForSeconds(delayShowPanelQuit);
        panelQuit.SetActive(true);
        paneBackGroundMain.SetActive(false);

    }
    public IEnumerator DelayOffPanelQuit() 
    {
        yield return new WaitForSeconds(delayOffPanelQuit);
        paneBackGroundMain.SetActive(true);
        panelQuit.SetActive(false);

    }

    private void Start()
    {
        paneBackGroundMain.SetActive(true);
        panelOption.SetActive(false);
        panelQuit.SetActive(false);
        panelGameSetting.SetActive(false);
        optionContainer.SetActive(true);
    }
}
