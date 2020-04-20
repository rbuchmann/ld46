using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamestarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartGame() {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    public void onEndGame() {
        Application.Quit();
    }
}
