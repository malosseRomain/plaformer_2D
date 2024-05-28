using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint; //index du target stocké dans waypoints

    void Start()
    {
        target = waypoints[0];
    }

    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //Si l'ennemi n'attaque pas 
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length; //permet d'aller chercher le waypoint suivant que ce soit en aller ou en retour 
            target = waypoints[destPoint];
        } 
    }
}
