using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject AffichageMenu;
    public GameObject ParamFenetre;
    public static GameOver instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de GameOver");
            return ;
        }
        instance = this;
    }


    public void IfPlayerDead()
    {
        AffichageMenu.SetActive(true); 
    }



    public void bouttonMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void bouttonOpenParam()
    {
        ParamFenetre.SetActive(true);
    }

    public void bouttonCloseParam()
    {
        ParamFenetre.SetActive(false);
    }

    public void bouttonRecommencer()
    {
        Inventory.instance.RmoveCoins(GestionSceneCourante.instance.CptCoinSceneCourante);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthPlayer.instance.RespawnPlayer();
        AffichageMenu.SetActive(false);
    }

    public void bouttonExit()
    {
        Application.Quit();
    }

}
