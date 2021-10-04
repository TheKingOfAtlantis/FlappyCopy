using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.Instance.gameOver)
        {
            transform.position += Vector3.left * speed;
            if(transform.position.x < -3f)
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
