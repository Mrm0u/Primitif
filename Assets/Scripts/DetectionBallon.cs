using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBallon : MonoBehaviour
{
    private float points = 0;
    public bool spawn = true;
    private SpawnManager spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("spawnBallon").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        points = points + 1;
        Debug.Log(points);
        
        if (points >= 3)
        {
            spawn = false;
            spawnManagerScript.Ballon = null;
            Debug.Log("Vous avez gagné!");
            
         }
    }
}
