using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelettiSpawner : MonoBehaviour
{

    const float MAX_COOLDOWN = 2;
    const int MAX_SKELETTIS = 5;
    float cooldown;
    bool ready;

    public GameObject skelettiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = MAX_COOLDOWN;
        ready = false;
    }

    void SpawnSkeletti() {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-5, 5);

        Vector3 spawnPoint = new Vector3(x, y, 0).normalized * 7.0f;
        
        Instantiate(skelettiPrefab, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0) {
            ready = true;
            cooldown = 0;
        }

        int num_skelettis = GameObject.FindGameObjectsWithTag("skeletti").Length;

        if ((num_skelettis < MAX_SKELETTIS) && ready) {
            SpawnSkeletti();
            ready = false;
            cooldown = MAX_COOLDOWN;
        }
    }
}
