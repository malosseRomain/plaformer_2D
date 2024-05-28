using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    private GameObject[] checkpoints;
    Transform parentTransform;

    void Start()
    {
        parentTransform = GetComponent<Transform>();
        int childCount = parentTransform.childCount;
        checkpoints = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
            checkpoints[i] = parentTransform.GetChild(i).gameObject;
        
        //On place le spawnPoint au premier checkpoint
        checkpoints[0].GetComponent<CheckPointControl>().SpawnTransform.position = checkpoints[0].GetComponent<Transform>().position;
    }

    public void CheckPointVisited(int ind)
    {
        //Lorsque le joueur passe par un checkpoint on attribue le prochain checkpoint et désactive tous les précédents
        //Si le joueur évite un checkpoint et passe par le suivant le système fonctionnera toujours 
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint != null && checkpoint.GetComponent<CheckPointControl>().positionList <= ind)    
            {
                Destroy(checkpoint);
            }
        }
    }
}
