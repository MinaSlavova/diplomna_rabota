using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health = 20;
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
                transform.rotation = Quaternion.Euler(-30, 180, 0);
            }
            else if (transform.position.x > oldPositionX)
            {
                transform.rotation = Quaternion.Euler(30, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= attackTime)
            {
                timer = 0;
                collision.gameObject.GetComponent<Health>().Damage(damage);
            }
        }
    }

    public void ItemDrop()
    {
        for(int i = Random.Range(0, itemDrops.Length); i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[Random.Range(0, itemDrops.Length)], transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }

    public void Damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        ItemDrop();
        Score.score += 20;
        Destroy(gameObject);
    }
}
