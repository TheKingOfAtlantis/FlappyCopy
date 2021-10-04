using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.Instance.gameOver)
        {
            transform.position += Vector3.left * velocity;
            var viewportPos = Camera.main.WorldToViewportPoint(transform.position);
            if(viewportPos.x < Camera.main.rect.xMin - 0.1)
                gameObject.SetActive(false);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.addPoint();
    }

}
