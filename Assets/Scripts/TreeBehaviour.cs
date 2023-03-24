using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject appleDrop;
    private float dropTime;
    private float timer = 0f;

    private void Start()
    {
        dropTime = Random.Range(1f, 1000f);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dropTime)
        {
            timer = 0;
            dropTime = Random.Range(1f, 1000f);
            Instantiate(appleDrop, transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }
}
