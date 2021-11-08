using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W5toL2 : MonoBehaviour
{

    private float myTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        myTimer -= Time.deltaTime;
        if(myTimer <= 0)
        {
            SceneManager.LoadScene(24);
        }
    }
}
