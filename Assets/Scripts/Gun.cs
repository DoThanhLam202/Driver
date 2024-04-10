using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject buttet;
    public Transform bulletSpawn;
    private float bulletVelocity = 30f;
    private float destroyBullet = 3f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(buttet, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized *  bulletVelocity, ForceMode.Impulse);
        StartCoroutine(destroyBulletAfter(bullet, destroyBullet));
    }

    IEnumerator destroyBulletAfter(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}
