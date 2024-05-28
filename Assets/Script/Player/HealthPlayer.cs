using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxVie = 100;
    public int VieCourante;
    public BarreDeVie BarreVie;
    public bool Immortel = false;
    public SpriteRenderer sRD;
    public float Time_clignottement_Immortel = 0.15f;
    public float Immortel_time = 1.5f; 
    public AudioClip DamageSound;	

    public static HealthPlayer instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de Player");
            return ;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        VieCourante = maxVie;
        BarreVie.SetMaxHealth(maxVie);
    }

    public void takeHealth(int health)
    { 
        if (VieCourante + health > maxVie)
        {
            VieCourante = maxVie;
        }
        else    
            VieCourante += health;
        BarreVie.SetHealth(VieCourante);
    }

    public void TakeDamage(int Damage)
    {
        if (!Immortel)
        {
            AudioManager.instance.PlayClip(DamageSound, transform.position);
            VieCourante -= Damage;
            BarreVie.SetHealth(VieCourante);

            if (VieCourante <= 0)
            {
                Death();
                return;
            }

            Immortel = true;
            StartCoroutine(Immortel_Clignottement());
            StartCoroutine(Mortel_delai());
        }
    }

    public void Death()
    {
        PlayerController.instance.enabled = false; //desactiver le script permmettant de bouger
        PlayerController.instance.playerAnim.SetTrigger("Death");
        PlayerController.instance.playerRB.bodyType = RigidbodyType2D.Static; 
        PlayerController.instance.playerCollider.enabled = false;
        GameOver.instance.IfPlayerDead();
    }

    public void RespawnPlayer()
    {
        PlayerController.instance.enabled = true;
        PlayerController.instance.playerAnim.SetTrigger("Respawn");
        PlayerController.instance.playerRB.bodyType = RigidbodyType2D.Dynamic;
        PlayerController.instance.playerCollider.enabled = true;
        VieCourante = maxVie;
        BarreVie.SetHealth(VieCourante);
    }

    public IEnumerator Immortel_Clignottement()
    {
        while(Immortel)
        {
            sRD.color = new Color32(255,255,255,0);
            yield return new WaitForSeconds(Time_clignottement_Immortel);
            sRD.color = new Color32(255,0,0,255);
            yield return new WaitForSeconds(Time_clignottement_Immortel);
        }

        if(!Immortel)
        {
            sRD.color = new Color32(255,255,255,255);
        }
    }

    public IEnumerator Mortel_delai()
    {
        yield return new WaitForSeconds(Immortel_time);
        Immortel = false;
    }    
}
