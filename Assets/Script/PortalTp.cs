using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTp : MonoBehaviour
{
    public string NameOfScene;
    public AudioClip TpSound;	

    private void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(ChangeSceneAfterDelay(col));
    }

    private IEnumerator ChangeSceneAfterDelay(Collider2D col)
    {
        Sauvegarde.instance.SaveData();
        AudioManager.instance.PlayClip(TpSound, transform.position);
        yield return new WaitForSeconds(0.3f); // Attendre la durée de la musique 
        SceneManager.LoadScene(NameOfScene); // "Niveau_2"
    }
}
 