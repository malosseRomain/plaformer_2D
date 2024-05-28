using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject FenettreMenu;     

    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    
    public void SettingButton()
    {
        FenettreMenu.SetActive(true);
    }

        public void ClosingSettingMenu()
    {
        FenettreMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}