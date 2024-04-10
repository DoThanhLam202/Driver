using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public GameObject player;
    public GameObject zombie;
    private float initialSpawnDelay = 5f;
    private float spawnDelayDecrease = 0.2f;
    private float minSpawnDelay = 0.2f;
    private bool canDecreaseSpawnDelay = true;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (player)
        {
            SpawnZombie();
            yield return new WaitForSeconds(initialSpawnDelay);

            // Giảm tốc độ spawn sau mỗi 10 giây nếu có thể giảm
            if (canDecreaseSpawnDelay && Time.time % 10 == 0)
            {
                initialSpawnDelay -= spawnDelayDecrease;
                // Đảm bảo tốc độ spawn không nhỏ hơn giá trị tối thiểu
                if (initialSpawnDelay < minSpawnDelay)
                    initialSpawnDelay = minSpawnDelay;
                // Kiểm tra điều kiện để ngừng giảm tốc độ spawn
                if (initialSpawnDelay <= 1f)
                    canDecreaseSpawnDelay = false;
            }
        }
    }
    void SpawnZombie()
    {
        float spawnX = Random.Range(-26f, 26f);
        float spawnZ = Random.Range(-26f, 26f);
        Vector3 spawnPosition = new Vector3(spawnX, zombie.transform.position.y, spawnZ);
        Instantiate(zombie, spawnPosition, zombie.transform.rotation);
    }
}