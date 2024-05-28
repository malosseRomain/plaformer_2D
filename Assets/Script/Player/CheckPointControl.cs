using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    public int positionList;
    public Transform SpawnTransform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SpawnTransform.position = transform.position;
            transform.parent.gameObject.GetComponent<CheckPointsManager>().CheckPointVisited(positionList);
        }
    }
}
