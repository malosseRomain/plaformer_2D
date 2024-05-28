using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target; 
    public float smoothing = 8f;
    public Vector3 posOffset;
    Vector3 offset;

    private Vector3 velocity;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    { 
        Vector3 targetCamPosition = target.position + offset; 
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, target.position + posOffset, ref velocity, smoothing); // pour pouvoir d�centrer le perosnnage de la camera
        // if(HealthPlayer.instance.VieCourante <= 0)
        // {
        //     transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // }  
    }
}
