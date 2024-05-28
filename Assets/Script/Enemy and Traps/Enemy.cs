using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] Points;
    public SpriteRenderer SnakeRenderer;
    public int DamageCollision;

    private Transform target;
    private int DestinationPoint = 0;
    private FollowingHealthBar healthBarScript;

    void Start()
    {
        target = Points[0];
        healthBarScript = FollowingHealthBar.Instance;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            DestinationPoint = (DestinationPoint + 1) % Points.Length;
            target = Points[DestinationPoint];
            SnakeRenderer.flipX = !SnakeRenderer.flipX;
        }

        if (healthBarScript != null)
        {
            healthBarScript.SetHealth(transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            HealthPlayer healthPlayer = col.transform.GetComponent<HealthPlayer>();
            healthPlayer.TakeDamage(DamageCollision);
        }
    }
}
