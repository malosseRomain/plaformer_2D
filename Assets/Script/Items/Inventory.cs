using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int CptCoins;
    public Text CoinsText;
    public  List<ItemInventaire> content = new List<ItemInventaire>();
    public Image ImageItemUI;
    public Sprite NoItemImage;
    public Text NameItemUI;
    public PlayerEffect playerEffect;
    public static Inventory instance;

    private int contentCurrentIndex = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de l'inventaire");
            return ;
        }
        instance = this;
    }

    
    private void Start()
    {
        UpdateImageItemUI();
    }

    public void AddCoins(int cpt)
    {
        CptCoins += cpt;
        UpdateCoinOnUI();
    }

    public void RmoveCoins(int cpt)
    {
        CptCoins -= cpt;
        UpdateCoinOnUI();
    }

    public void UpdateCoinOnUI()
    {
        CoinsText.text = CptCoins.ToString();
    }

    public void UseItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        ItemInventaire currentItem = content[contentCurrentIndex];
        HealthPlayer.instance.takeHealth(currentItem.hpToGive);
        playerEffect.addSpeed(currentItem.SpeedToGive, currentItem.speedDuration);
        playerEffect.addJump(currentItem.Jump, currentItem.JumpDuration);
        playerEffect.ChangeScale(currentItem.NewScale, currentItem.ChangeScaleDuration);
        playerEffect.DoubleJump(currentItem.NbSautSup, currentItem.DoubleJumpDuration);
        content.Remove(currentItem);
        GetNexItem();
        UpdateImageItemUI();
    }

    public void GetNexItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateImageItemUI();
    }
    
    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateImageItemUI();
    }

    public void UpdateImageItemUI()
    {
        if(content.Count > 0)
        {
            ImageItemUI.sprite = content[contentCurrentIndex].image;
            NameItemUI.text =  content[contentCurrentIndex].name;
        }
        else
        {
            ImageItemUI.sprite = NoItemImage;
            NameItemUI.text = "";
        }
    }

}
