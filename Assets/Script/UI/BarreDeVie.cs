using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image remplissage;

    public void SetMaxHealth(int Health)
    {
        // Vie Max
        slider.maxValue = Health;   
        // Vie actuelle
        slider.value = Health;

        // Initialiser la barre de vie en vert (1f = valeur à droite)
        remplissage.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int Health)
    {
        // Modifier la vie du boss
        slider.value = Health;
        // Adapter la valeur de la vie pour le gradient, donc compris entre 0 et 1
        remplissage.color = gradient.Evaluate(slider.normalizedValue);
    }
}
