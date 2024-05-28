using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoints : MonoBehaviour
{
    private PlayerController playerController;
    public Transform SpawnPoints;

    void Start()
    {
        playerController = PlayerController.instance;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            HealthPlayer.instance.TakeDamage(40);
            playerController.gameObject.GetComponent<Transform>().position = SpawnPoints.position;
        }   
    }


}
