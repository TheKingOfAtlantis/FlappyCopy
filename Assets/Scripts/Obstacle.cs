using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float timeSeperation = 1f;
    public float displacement   = 1f;

    private float lastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawned = displacement; // This is so we spawn a tube immediately
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.Instance.gameOver)
        {
            if(Time.time - lastSpawned > timeSeperation)
            {
                var obj = ObjectPool.Instance.GetObject("tube");
                if(obj != null)
                {
                    obj.transform.position = new Vector3(
                        Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0 )).x,
                        Random.Range(-displacement, displacement)
                    );
                    obj.SetActive(true);
                }
                lastSpawned = Time.time;
            }
        }
    }
}
