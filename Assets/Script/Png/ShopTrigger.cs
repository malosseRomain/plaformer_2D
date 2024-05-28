using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public ItemInventaire[] ItemToSell;
    public string PngName;

    private Transform TextToucheUI;


    private void Awake()
    {
        TextToucheUI = gameObject.transform.GetChild(0);
        TextToucheUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            TextToucheUI.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            ShopManager.instance.OpenShop(ItemToSell, PngName);
    }  

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            TextToucheUI.gameObject.SetActive(false);
            ShopManager.instance.CloseShop();
        }
    }
}
