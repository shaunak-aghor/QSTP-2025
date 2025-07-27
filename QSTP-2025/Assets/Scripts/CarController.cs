using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //left/right and a/d keys should rotate the car.
    //up/down and w/s keys should move the car forward and backward.
    public float rotationSpeed, moveSpeed, boostMultiplier;
    public Transform cartransform;





    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");


        //Debug.Log("horizontal:" + horizontalMovement + "vertical:" + verticalMovement);

        if (Math.Abs(horizontalMovement) > 0.01f)
        {
            cartransform.Rotate(0f, 0f, -1 * rotationSpeed * horizontalMovement * Time.deltaTime);
        }
        if (Math.Abs(verticalMovement) > 0.01f)
        {
            cartransform.Translate(0f, moveSpeed * verticalMovement * Time.deltaTime, 0f);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedHouse")
        {
            Debug.Log("I've hit a Red House");
        }
        if (collision.gameObject.tag == "BlueHouse")
        {
            Debug.Log("I've hit a Blue House");
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = moveSpeed * boostMultiplier;
            Destroy(other.gameObject);
        }
    }
}
