using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoundBossArea : MonoBehaviour
{
    public Text messageText;
    public Collider2D AreaCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            messageText.text = "Attention !\nVous ne pouvez pas revenir en arriere une fois la zone du boss atteinte.";
            AreaCollider.enabled = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MyCoroutine());
        }
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        messageText.text = "";
    }

}
