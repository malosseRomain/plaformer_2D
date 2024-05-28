using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoixNiv : MonoBehaviour
{
    public Button[] BouttonsNiv;


    private void Start()
    {
        int NivAtteint = PlayerPrefs.GetInt("NivAtteint", 1);
        for (int i = 0; i < BouttonsNiv.Length; i++)
        {
            if(i+1 > NivAtteint)
                {
                    BouttonsNiv[i].interactable = false;
                }
        }
    }

    public void NivToCharge(string NivName)
    {
        SceneManager.LoadScene(NivName);
    }
}
