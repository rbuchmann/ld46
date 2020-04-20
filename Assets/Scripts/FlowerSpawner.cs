using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerPrefab;

    float cooldown;

    const int MAX_COOLDOWN = 5;

    const int MAX_FLOWERS = 10;


    void spawnFlower() {
        

        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        
        Instantiate(flowerPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MAX_FLOWERS; i++) {
            spawnFlower();
        }

        cooldown = MAX_COOLDOWN;
    }

    void Update() {
        cooldown -= Time.deltaTime;

        int num_flowers = GameObject.FindGameObjectsWithTag("flower").Length;

        if ((cooldown <= 0) && (num_flowers < MAX_FLOWERS)) {
            spawnFlower();
            cooldown = MAX_COOLDOWN;
        }
    }
}
