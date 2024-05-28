using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float TempsEntreAttaque;
    bool canAttack = true;

    void Update()
    {
        int PVCourant = transform.GetChild(0).gameObject.GetComponent<PointFaibleBoss>().VieCourante;
        if (canAttack && PVCourant > 0)
            StartCoroutine(AttackWithDelay(TempsEntreAttaque));
    }

    public IEnumerator AttackWithDelay(float TempsEntreAttaque)
    {
        canAttack = false;

        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        FireballMovement fireballScript = fireball.GetComponent<FireballMovement>();
        
        if (fireballScript != null)
        {
            print("flipX = " + GetComponent<SpriteRenderer>().flipX);
            fireballScript.direction = GetComponent<SpriteRenderer>().flipX;
        }

        yield return new WaitForSeconds(TempsEntreAttaque);

        canAttack = true;

    }
}
