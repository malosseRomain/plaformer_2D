using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerController playerMovement;
    public BoxCollider2D topCollider;
    private Transform interactUITop;
    private Transform interactUIBottom;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        interactUITop = gameObject.transform.GetChild(1);
        interactUIBottom = gameObject.transform.GetChild(2);
        ToggleUI(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ToggleUI(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(playerMovement.Climbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.Climbing = false;
            topCollider.isTrigger = false;
            ToggleUI(true);
            return;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.Climbing = true;
            topCollider.isTrigger = true;
            ToggleUI(false);
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.Climbing = false;
            topCollider.isTrigger = false;
            ToggleUI(false);
        }
    }

    private void ToggleUI(bool val) {
        interactUITop.gameObject.SetActive(val);
        interactUIBottom.gameObject.SetActive(val);
    }
}