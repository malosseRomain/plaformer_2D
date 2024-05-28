using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBDD : MonoBehaviour
{
    public ItemInventaire[] Allitems;
    public static ItemsBDD instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de ItemsBDD");
            return ;
        }
        instance = this;
    }
}
