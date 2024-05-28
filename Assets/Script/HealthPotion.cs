using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int HealthNumber;
    public AudioClip HealthSound;	

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) //&& HealthPlayer.instance.VieCourante > HealthPlayer.instance.maxVie
        {
           
            if (HealthPlayer.instance.VieCourante < HealthPlayer.instance.maxVie)
            {
                HealthPlayer.instance.takeHealth(HealthNumber);
                Destroy(gameObject);
                AudioManager.instance.PlayClip(HealthSound, transform.position);
            }
        }
    }
    
}
