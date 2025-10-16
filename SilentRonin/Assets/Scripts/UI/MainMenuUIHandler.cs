using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{

    [Header("Panel")]
    public GameObject paneBackGroundMain;
    public GameObject panelOption; // Panel cài đặt
    public GameObject panelQuit;// Panel xác nhận thoát game
   

    [Header("Thong so")]
    public float delayShowPanelOption = 0.5f;
    public float delayShowPanelQuit = 0.5f; // Thời gian chờ hiện panel xác nhận thoát game
    public float delayOffPanelQuit = 0.5f;
   
    public void OnStartGame()
    {
        SceneManager.LoadScene("Level_01"); 
    }


    // Gọi khi bấm "Achievements"
    public void OnAchievements()
    {
        Debug.Log("Achievements opened");
        // TODO: mở panel thành tựu
    }

    // Gọi khi bấm "Option"
    public void OpenPanelOption()
    {
        StartCoroutine(DelayShowPanelOption());
    }
    public void OffPanelOption()
    {
        StartCoroutine(DelayOffPanelOption());
    }


    // Gọi khi bấm "Quit Game"
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
    //Option
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

    //panel quit
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
}
