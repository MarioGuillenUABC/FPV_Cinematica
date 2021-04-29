using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Transform target;
    public float smoothTime;
    void Start()
    {
        target = FindObjectOfType<Bala>().transform;    

    }

    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothTime);
    }
}
