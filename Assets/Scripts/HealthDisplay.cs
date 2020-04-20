using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Image[] flowers;
    public Image[] hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            flowers[i].enabled = false;
            hearts[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlimeJumpManual jumper =  GameObject.FindWithTag("Player").GetComponent<SlimeJumpManual>();

        int n_hearts = jumper.health;
        int n_flowers = jumper.flowers;

        for (int i = 0; i < 3; i++) {
            if (i < n_hearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }

            if (i < n_flowers) {
                flowers[i].enabled = true;
            } else {
                flowers[i].enabled = false;
            }
        }
    }
}
