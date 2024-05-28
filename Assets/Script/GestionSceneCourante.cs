using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSceneCourante : MonoBehaviour
{
    public int CptCoinSceneCourante;
    public Vector3 PointRespawn;
    public int NivDebloquer;
    public static GestionSceneCourante instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de GestionSceneCourante");
            return ;
        }
        instance = this;
        PointRespawn = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
