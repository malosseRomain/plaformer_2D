using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointFaibleBoss : MonoBehaviour
{
    public AudioClip DeadSound;    
    public int heart = 2; 
    public Enemy enemyScript;
    public Animator animator;
    public Text EndingmessageText;
    public bool Immortel = false;
    public GameObject endBoundFront;
    public GameObject endBoundBack;
    public BarreDeVie BossHealthBar;
    public int maxVie = 100;
    public int VieCourante;
    public bool finalBoss;

    private float AnimImmortelTime = 2f; 
    private BoxCollider2D boxCollider2D;
    private BoxCollider2D parentBoxCollider2D;

    private void Awake()
    {
        parentBoxCollider2D = transform.parent.GetComponent<BoxCollider2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        VieCourante = maxVie;
        BossHealthBar.SetMaxHealth(maxVie);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && heart == 1)
        {
            boxCollider2D.enabled = false;
            parentBoxCollider2D.enabled = false;
            StartCoroutine(DeathAnimation());
            enemyScript.speed = 0f;
            if (finalBoss)
                StartCoroutine(EndOfGame());
        }
        else if (col.CompareTag("Player") && !Immortel)
        {
            Immortel = true;
            StartCoroutine(InvisibleAnimation());
        }
    }

    public IEnumerator DeathAnimation()
    {
        AudioManager.instance.PlayClip(DeadSound, transform.position);
        VieCourante -= 34;
        BossHealthBar.SetHealth(VieCourante);
        animator.SetInteger("NbHeart", -1);
        yield return new WaitForSeconds(1.1f);
        Destroy(endBoundFront);
        Destroy(endBoundBack);
    }

    public IEnumerator InvisibleAnimation()
    {
        AudioManager.instance.PlayClip(DeadSound, transform.position);
        VieCourante -= 34;
        BossHealthBar.SetHealth(VieCourante);
        animator.SetBool("IsHurt", true);
        yield return new WaitForSeconds(AnimImmortelTime);
        Immortel = false;
        animator.SetBool("IsHurt", false);
        heart--;
    }

    public IEnumerator EndOfGame()
    {
        EndingmessageText.text = ("BRAVO VOUS AVEZ VAINCU LE BOSS ET FINI LE JEU !!!");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Generique");
    }
}
