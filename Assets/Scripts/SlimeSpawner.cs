using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeSpawner : MonoBehaviour
{
    const int START_SLIMES = 3;
    const float SLIME_LIFE = 5;

    float cooldown;
    public GameObject slimePrefab;

    Vector3 myLocation;
    public List<GameObject> slimes;
    // Start is called before the first frame update

    GameObject spawnSlime() {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);
        
        return Instantiate(slimePrefab, myLocation + new Vector3(x, y, 0), Quaternion.identity);
    }
    void Start()
    {
        myLocation = GetComponent<Transform>().position;
        cooldown = SLIME_LIFE;

        for (int i=0; i < START_SLIMES; i++) {
            slimes.Add(spawnSlime());
        }
    }

    public void addSlimes(int num_new) {
        for (int i=0; i < num_new; i++) {
            slimes.Add(spawnSlime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0) {
            cooldown = SLIME_LIFE;

            if (slimes.Count > 0) {
                GameObject delSlime = slimes[0];
                slimes.Remove(delSlime);
                Destroy(delSlime);
            }

            if (slimes.Count == 0) {
                SceneManager.LoadScene("Outro", LoadSceneMode.Single);
            }
        }
    }
}
