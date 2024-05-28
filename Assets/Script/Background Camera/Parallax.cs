using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startpos;
    new public GameObject camera;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;    
    }

    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, camera.transform.position.y, transform.position.z);    
    }
}
