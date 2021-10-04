using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float forceMagnitude; // Magnitude of the force to be applied to the bird
    
    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator  = GetComponent<Animator>();

        rigidBody.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameController.Instance.gameOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rigidBody.gravityScale = 1f;
                GameController.Instance.startGame();
                if(isDead)
                {
                    transform.position = Vector3.left * 2;
                    transform.rotation = Quaternion.identity;
                    isDead = false;
                    animator.SetTrigger("Start");
                }
            }
        } 
        else if (isDead == false) // Animate the bird as long as it's not dead
        {
            // If we are given an input
            if (Input.GetMouseButton(0) || Input.GetKeyDown("space"))
            {
                // Make the bird move upwards
                rigidBody.velocity = Vector2.zero;
                rigidBody.AddForce(Vector2.up * forceMagnitude);
                // And aniamte it flapping
                animator.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If we hit something
        // Kill the bird :(
        animator.SetTrigger("Die");
        isDead = true;
        GameController.Instance.triggerGameOver();
    }
}
