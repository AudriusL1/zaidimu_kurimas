using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }
    }
}
