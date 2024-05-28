using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInventaire", menuName =("Inventory/ItemInventaire"))]
public class ItemInventaire : ScriptableObject
{
    public Sprite image;
    public int Id;
    public new string name;
    public string description;
    public int hpToGive;
    public int SpeedToGive;
    public float speedDuration; 
    public int Jump;
    public float JumpDuration; 
    public int price;
    public float NewScale;
    public float ChangeScaleDuration;
    public int NbSautSup;
    public float DoubleJumpDuration;
}
