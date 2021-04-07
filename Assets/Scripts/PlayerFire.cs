using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.transform.position = transform.position;
        }
    }
}
