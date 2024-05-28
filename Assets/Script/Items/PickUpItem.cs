    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class PickUpItem : MonoBehaviour
    {
        public ItemInventaire item;
        public AudioClip SoundPickUpItem;

        private Transform interactionUI;


        private void Awake()
        {
            interactionUI = gameObject.transform.GetChild(0);
            interactionUI.gameObject.SetActive(false);
        }


        private void TakeItem()
        {
            Inventory.instance.content.Add(item);
            Inventory.instance.UpdateImageItemUI();
            AudioManager.instance.PlayClip(SoundPickUpItem, transform.position);
            interactionUI.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
                interactionUI.gameObject.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.R))
                TakeItem();
        }   

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
                interactionUI.gameObject.SetActive(false);
        }
    }
