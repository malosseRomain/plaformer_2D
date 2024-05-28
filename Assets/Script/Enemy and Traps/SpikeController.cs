using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float Intervalle;
    public bool spikesActive;
    float timer = 0f;
    public int damage;

    public Sprite SpikeUP;
    public Sprite SpikeDOWN;
    private SpriteRenderer SpikeSprite;
    private BoxCollider2D SpikeCollider;

    PlayerController playerController;
    HealthPlayer playerHealth;
    GameObject Player;
    Rigidbody2D playerRB;

    void Start()
    {
        SpikeSprite = GetComponent<SpriteRenderer>();
        SpikeCollider = GetComponent<BoxCollider2D>();
        SetSpikesActive(spikesActive);

        Player = GameObject.FindWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        playerHealth = Player.GetComponent<HealthPlayer>();
        playerRB = Player.GetComponent<Rigidbody2D>();

        if (spikesActive)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.22f, transform.position.z);
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        if (timer >= Intervalle)
        {
            SetSpikesActive(!spikesActive);
            timer = 0f;
        }
    }

    void SetSpikesActive(bool active)
    {  
        if (active)
        {
            SpikeSprite.sprite = SpikeUP;
            transform.localScale = new Vector3(4.7123f, 4.7123f, 4.7123f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.22f, transform.position.z);
                
            SpikeCollider.enabled = true;
            spikesActive = true;
        }
        else
        {
            SpikeSprite.sprite = SpikeDOWN;
            transform.localScale = new Vector3(0.09921058f, 0.09921058f, 0.09921058f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.22f, transform.position.z);
            SpikeCollider.enabled = false;
            spikesActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

                float jumpPower = playerController.jumpPower;
                playerRB.AddForce(new Vector2(0, jumpPower/2), ForceMode2D.Impulse);
                playerHealth.TakeDamage(damage);
        }
    }
}
