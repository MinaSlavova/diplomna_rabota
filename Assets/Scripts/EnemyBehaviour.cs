using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject enemyDetectionRange;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private int damage = 5;
    [SerializeField] private GameObject[] itemDrops;
    [SerializeField] private float attackTime = 0.75f;
    private float timer = 0f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float oldPositionX = transform.position.x;
        if(enemyDetectionRange.GetComponent<PlayerDetection>().found == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if (transform.position.x < oldPositionX)
            {
                gameObject.transform.localScale = new Vector3(-1f, transform.localScale.y);
            }
            else if (transform.position.x > oldPositionX)
            {
                gameObject.transform.localScale = new Vector3(1f, transform.localScale.y);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= attackTime)
            {
                timer = 0;
                other.GetComponent<Health>().Damage(damage);
            }            
        }
    }

    public void ItemDrop()
    {
        for(int i = Random.Range(0, itemDrops.Length); i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[Random.Range(0, itemDrops.Length)], transform.position + new Vector3(0, Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }
}
