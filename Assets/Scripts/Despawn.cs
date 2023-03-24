using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] private float despawnTime = 60f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= despawnTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
