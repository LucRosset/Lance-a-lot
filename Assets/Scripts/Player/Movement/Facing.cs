using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    [SerializeField] private float minVelocity = 1f;

    private Rigidbody2D myRigidbody;
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flip from right to left
        if (!myRenderer.flipX && myRigidbody.velocity.x < -minVelocity)
            myRenderer.flipX = true;
        // Flip from left to right
        else if (myRenderer.flipX && myRigidbody.velocity.x > minVelocity)
            myRenderer.flipX = false;
    }
}
