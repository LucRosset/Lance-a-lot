using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float pushForce = 100f;
    [SerializeField] private float maxVelocity = 2f;

    private Rigidbody2D myRigidbody;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newVelocity = myRigidbody.velocity;
        newVelocity.x = Mathf.Clamp(
            newVelocity.x,
            -maxVelocity,
            maxVelocity
        );
        myRigidbody.velocity = newVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
            MovePlayer(Input.GetAxis("Horizontal"));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
            onGround = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wall")
            onGround = false;
    }

    private void MovePlayer(float direction)
    {
        myRigidbody.AddForce(direction * pushForce * Vector2.right * Time.deltaTime);
    }
}
