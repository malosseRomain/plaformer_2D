using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generique : MonoBehaviour
{
    public void ChargerMenuPrinc()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ChargerMenuPrinc();
        }
    }
}
