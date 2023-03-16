using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float dropForce = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * dropForce, ForceMode.Impulse);
    }
}
