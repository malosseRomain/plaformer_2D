using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    private Transform Interact_UI;

    public Animator animator;
    public int CoinsToGive;
    public AudioClip Sound;

    void Awake()
    {
        Interact_UI = gameObject.transform.GetChild(0);
        Interact_UI.gameObject.SetActive(false);
    }


    void openChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(CoinsToGive);
        AudioManager.instance.PlayClip(Sound,transform.position);
        GetComponent<BoxCollider2D>().enabled=false;
        Interact_UI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Interact_UI.gameObject.SetActive(true);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            openChest();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Interact_UI.gameObject.SetActive(false);
    }
}
