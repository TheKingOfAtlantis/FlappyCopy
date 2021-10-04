using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxScroll : MonoBehaviour
{

    public float velocity = 0.0025f;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocity;
        if(transform.position.x <= -7)
        {
            var pos = transform.position;
            pos.x = 0;
            transform.position = pos;
        }
    }
}
