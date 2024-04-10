using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float speedMove = 5f;
    public Transform player;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    private void FixedUpdate()
    {
        if (!IsOwner) return;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = player.forward * verticalInput + player.right * horizontalInput;
        transform.position += moveDirection.normalized * speedMove;
    }
}
