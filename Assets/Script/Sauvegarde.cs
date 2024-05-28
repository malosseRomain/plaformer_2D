using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sauvegarde : MonoBehaviour
{

    public static Sauvegarde instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de Sauvegarde");
            return ;
        }
        instance = this;
    }

    void Start()
    {
        Inventory.instance.CptCoins = PlayerPrefs.GetInt("NbCoins", 0);
        Inventory.instance.UpdateCoinOnUI();

        string[] itemsSaved = PlayerPrefs.GetString("InventoryItems","").Split(',');
        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);
                ItemInventaire CurrentItem = ItemsBDD.instance.Allitems.Single(x => x.Id == id);
                Inventory.instance.content.Add(CurrentItem);
            }
        }
        Inventory.instance.UpdateCoinOnUI();    

        // int vieCourante = PlayerPrefs.GetInt("HealthOfPlayer", HealthPlayer.instance.maxVie);
        // HealthPlayer.instance.VieCourante = vieCourante;                
        // HealthPlayer.instance.BarreVie.SetHealth(vieCourante);
        // Je n'est pas reussi à faire en sorte de garder la vie de mon personnage en utilisant les PlayerPrefs comme pour les coins, la vie de mon joueur se remet a chaque fois a 100hp et je ne comprend pas mon erreur
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("NbCoins", Inventory.instance.CptCoins);
        if(GestionSceneCourante.instance.NivDebloquer > PlayerPrefs.GetInt("NivAtteint",1))
        {
            PlayerPrefs.SetInt("NivAtteint", GestionSceneCourante.instance.NivDebloquer);
        }

        string ItemInInventaire = string.Join(",",Inventory.instance.content.Select(x => x.Id));
        PlayerPrefs.SetString("InventoryItems",ItemInInventaire);

        // PlayerPrefs.SetInt("HealthOfPlayer", HealthPlayer.instance.VieCourante);
        // Je n'est pas reussi à faire en sorte de garder la vie de mon personnage et le niveaux max atteint en utilisant les PlayerPrefs comme pour les coins, la vie de mon joueur se remet a chaque fois a 100hp et mon jeu ce reinitialise et je ne comprend pas mon erreur
    }
}
