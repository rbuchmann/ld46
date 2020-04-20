using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJumper : MonoBehaviour
{

    const float MAX_COOLDOWN = 2;
    const float MAX_SPEED = 2;
    bool newPosition;

    Vector3 target;

    float cooldown = MAX_COOLDOWN;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = true;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0) {
            newPosition = true;
            cooldown = 0;
        }

        Vector3 myPosition = GetComponent<Transform>().position;

        if (newPosition) {
            target = myPosition + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            newPosition = false;
            cooldown = MAX_COOLDOWN;
        }

        Vector3 speed = (target - myPosition).normalized * Mathf.Min(MAX_SPEED, (target - myPosition).magnitude);
        GetComponent<Transform>().SetPositionAndRotation(myPosition + speed * Time.deltaTime, Quaternion.identity);
    }
}
