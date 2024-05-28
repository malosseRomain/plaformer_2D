using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointFaible : MonoBehaviour
{
    public new GameObject DestroyObject;
    public AudioClip DeadSound;    


    private void OnTriggerEnter2D(Collider2D col)
    {
        AudioManager.instance.PlayClip(DeadSound, transform.position);

        if (col.CompareTag("Player"))
        {
            StartCoroutine(DelayedToDestroy());
        }
    }

    private IEnumerator DelayedToDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(DestroyObject);
    }
}
