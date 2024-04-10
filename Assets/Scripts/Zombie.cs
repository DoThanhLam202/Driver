using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private float speed = 40f;
    private float heal = 5;
    private bool isAlive;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    private void Update()
    {
        // Xoay về hướng người chơi
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if (isAlive)
        {
            rb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            heal--;
            if (heal <= 0)
            { isAlive = false; animator.SetTrigger("Dead"); Destroy(gameObject,2f); }
        }
        if(collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            animator.SetTrigger("Dead");
        }
    }
}
