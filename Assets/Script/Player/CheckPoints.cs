using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour
{
    public Text messageText;
    public string message;
    //public Transform Player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Vous avez atteint un check point");
        if (col.CompareTag("Player"))
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            // if(HealthPlayer.instance.VieCourante <= 0)
            // {
            //     Player.transform.position = transform.position;
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Check point enregistré");
        if (col.CompareTag("Player"))
        {
            messageText.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false; // pour empecher de pouvoir repasser par d ancien CHeckPoint
        }
    }
}


