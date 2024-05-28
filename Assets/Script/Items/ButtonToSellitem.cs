using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonToSellitem : MonoBehaviour
{
    public Text ItemName;
    public Text ItemPrice;
    public Image ItemImage;
    [HideInInspector]
    public ItemInventaire item;
    
    public void BuyItem()
    {
        Inventory Inventaire = Inventory.instance;
        if(Inventory.instance.CptCoins >= item.price)
        {
            Inventaire.content.Add(item);
            Inventaire.UpdateImageItemUI();
            Inventaire.CptCoins -= item.price;
            Inventaire.UpdateCoinOnUI();
        }
    }
}
