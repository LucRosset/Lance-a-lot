using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float pushForce = 100f;
    [SerializeField] private float maxVelocity = 2f;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private Collider2D[] colliders = new Collider2D[0];

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
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
        // if(CheckGround())
            MovePlayer(Input.GetAxis("Horizontal"));
    }

    private bool CheckGround()
    {
        myCollider.GetContacts(colliders);
        foreach (Collider2D col in colliders)
            if(col.tag == "Wall")
                return true;
        return false;
    }

    private void MovePlayer(float direction)
    {
        myRigidbody.AddForce(direction * pushForce * Vector2.right * Time.deltaTime);
    }
}
