using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;

    GameObject player;
    Vector3 dir;

    public GameObject explosionFactory;

    void Start()
    {
        player = GameObject.Find("Player");
        if(player != null)
        {
            int random = Random.Range(0, 100);

            if(random < 50)
            {
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        manager.enemyObjectPool.Add(gameObject);

        gameObject.SetActive(false);
    }
}