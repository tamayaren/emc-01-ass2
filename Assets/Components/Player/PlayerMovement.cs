using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class PlayerMovement : MonoBehaviour
{
    protected bool holdingLeftShift = false;
    
    private new Rigidbody2D rigidbody;

    public bool canMove = true;
    
    public float walkSpeed = 8f;
    public float runSpeed = 16f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!canMove) return;
        float yAxis = Input.GetAxis("Horizontal");
        float xAxis = Input.GetAxis("Vertical");

        holdingLeftShift = Input.GetKey(KeyCode.LeftShift);
        // Check if no input axis
        if ((yAxis + xAxis) != 0)
            Move(new Vector2(yAxis, xAxis));
    }

    private void Move(Vector2 inputData)
    {
        float dividend = Mathf.Abs(inputData.x) + Mathf.Abs(inputData.y);
        float speed = holdingLeftShift ? runSpeed : walkSpeed;
        
        Vector3 computed = new Vector3(((speed * inputData.x) / dividend), (speed * inputData.y) / dividend, 0);
        
        rigidbody.MovePosition(this.transform.position + (computed * Time.deltaTime));
    }
}
