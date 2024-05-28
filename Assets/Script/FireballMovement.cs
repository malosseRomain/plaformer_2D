using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public bool direction;
    public float speed;
    public int damage;

    void Update()
    {
        //direction : true = gauche
        //direction : false = droite

        if (direction) {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x -speed * Time.deltaTime, 0);
        }
        else {
            GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x + speed * Time.deltaTime, 0);
        }
        print ("transform.position.x + speed=" + (transform.position.x + speed));
        print ("transform.position.x - speed=" + (transform.position.x - speed));

        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<HealthPlayer>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
