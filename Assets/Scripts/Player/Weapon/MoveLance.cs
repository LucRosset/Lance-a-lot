using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLance : MonoBehaviour
{
    [SerializeField] private float rotationTorque = 1f;
    [SerializeField] private float maxVelocity = 1.5f;
    // DONT CHANGE THE MASS! IT MESSES UP THE VELOCITY CAP!

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myRigidbody.angularVelocity = Mathf.Clamp(
            myRigidbody.angularVelocity,
            -maxVelocity,
            maxVelocity
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("CounterClockwise"))
            Rotate(1f);
        if (Input.GetButton("Clockwise"))
            Rotate(-1f);
    }

    private void Rotate(float direction)
    {
        myRigidbody.AddTorque(rotationTorque * direction * Time.deltaTime);
    }
}
