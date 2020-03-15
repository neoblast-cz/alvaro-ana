using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    private GameObject cam;
    public float parallaxEffectScale;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = GameObject.Find("MainVirtualCamera");
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffectScale));
        float dist = (cam.transform.position.x * parallaxEffectScale);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
