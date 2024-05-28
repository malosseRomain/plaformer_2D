using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text PNGnametext;
    public Animator animator;
    public GameObject SellButtonPrefab;
    public Transform SellButtonsParent;
    public static ShopManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de ShopManager");
            return ;
        }
        instance = this;
    }


    public void OpenShop(ItemInventaire[] items, string PngName)
    {
        PNGnametext.text = PngName;
        UpdateItemsToSell(items);
        animator.SetBool("IsOpen", true);
    }

    private void UpdateItemsToSell(ItemInventaire[] items)
    {
        for (int i = 0; i < SellButtonsParent.childCount; i++)
        {
            Destroy(SellButtonsParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(SellButtonPrefab, SellButtonsParent);
            ButtonToSellitem buttonScript =  button.GetComponent<ButtonToSellitem>();
            buttonScript.ItemName.text = items[i].name;
            buttonScript.ItemImage.sprite = items[i].image;
            buttonScript.ItemPrice.text = items[i].price.ToString();
            buttonScript.item = items[i];
            button.GetComponent<Button>().onClick.AddListener(delegate {buttonScript.BuyItem();} ); //Ajouter l evenement OnClick avec la fct BuyItem
        }
    }

    public void CloseShop()
    {
        animator.SetBool("IsOpen", false);
    }
}
