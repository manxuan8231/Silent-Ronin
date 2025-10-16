using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public GameObject panelQuit;// Panel xác nhận thoát game
    [Header("UI MainMenu")]
    public GameObject button;
    public GameObject imageTitle;
    public GameObject imageGround;

    public void OnStartGame()
    {
        SceneManager.LoadScene("Level_01"); 
    }

    // Gọi khi bấm "Options"
    public void OnOptions()
    {
        Debug.Log("Options menu opened");
        // TODO: mở panel cài đặt
    }

    // Gọi khi bấm "Achievements"
    public void OnAchievements()
    {
        Debug.Log("Achievements opened");
        // TODO: mở panel thành tựu
    }

    // Gọi khi bấm "Quit Game"
    public void OpenPanelQuitGame()
    {
        panelQuit.SetActive(true);
        imageTitle.SetActive(false);
        imageGround.SetActive(false);
        button.SetActive(false);
    } 
    public void YesQuitGame()
    {
        Application.Quit();
       
    }
    public void NoQuitGame()
    {
       
        imageTitle.SetActive(true);
        imageGround.SetActive(true);
        button.SetActive(true);
        panelQuit.SetActive(false);
    }
}
