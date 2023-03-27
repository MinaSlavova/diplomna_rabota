using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public static float moveSpeed = 15;
    public Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + move * Time.deltaTime * moveSpeed);

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - transform.position).normalized;
        
        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(-30, 180, 0);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }

    }
}
