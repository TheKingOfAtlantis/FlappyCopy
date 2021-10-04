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
    }

    // Update is called once per frame
    void Update()
    {
        // Animate the bird as long as it's not dead
        if (isDead == false)
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
