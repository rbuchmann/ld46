using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num_slimes = GameObject.FindGameObjectsWithTag("villageslime").Length;
        string slimeText = "x " + num_slimes;

        GetComponent<Text>().text = slimeText;
    }
}
