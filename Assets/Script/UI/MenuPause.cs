using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool JeuPause = false;
    public GameObject UIpause;
    public GameObject ParamFenetre;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ParamFenetre.SetActive(false);//Pour ne pas reAvoir la fenettre de parametre si on fait echap en etant dessus. On retombe sur la fenetre pause
            if(JeuPause)
            {
                Reprendre();
            }
            else
            {
                Pause();
            }
        }
    }


void Pause()
{   
    //Pour empecher de pourvoir ouvrir le menu pause si le menu gameOver est deja ouvert. Cela me fesait des messages d"erreurs dans la console
    GameOver gameOver = FindObjectOfType<GameOver>();

    if (gameOver != null && !gameOver.AffichageMenu.activeSelf)
    {
        PlayerController.instance.enabled = false;
        UIpause.SetActive(true);
        Time.timeScale = 0;
        JeuPause = true;
    }
}

    public void Reprendre()
    {
        PlayerController.instance.enabled = true;
        UIpause.SetActive(false);
        Time.timeScale = 1;
        JeuPause = false;
    }


    public void OpenParamFenetre()
    {
        ParamFenetre.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ParamFenetre.SetActive(false);
        }
    }

    public void CloseParamFenetre()
    {
        ParamFenetre.SetActive(false);
    }


    public void LoadMainMenu()
    {
         Reprendre();
         SceneManager.LoadScene("MainMenu");
    }
}
