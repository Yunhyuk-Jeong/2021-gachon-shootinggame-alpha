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
        if (player != null)
        {
            int random = Random.Range(0, 100);

            if (random < 50)
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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject smObject = GameObject.Find("ScoreManager");

        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        sm.SetScore(sm.GetScore() + 1);

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}