using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsToPickUp : MonoBehaviour
{   
    public AudioClip Sound;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            AudioManager.instance.PlayClip(Sound, transform.position);
            Inventory.instance.AddCoins(1);
            GestionSceneCourante.instance.CptCoinSceneCourante++;
            Destroy(gameObject);
        }
    }
}


    
