using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + move * Time.deltaTime * moveSpeed);
        if(Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.localScale = new Vector3(-1f, transform.localScale.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.localScale = new Vector3(1f, transform.localScale.y);
        }
    }
}
