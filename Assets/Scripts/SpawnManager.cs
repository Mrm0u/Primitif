using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Ballon;
    private float spawnInterval = 5.5f;
    public bool fermeTimer = false;
    private Vector3 spawnPos = new Vector3(0, 1.25f, 11.06f);
    private DetectionBallon detectionBallonScript;
    private MouseControl mouseControlScript;
    // Start is called before the first frame update
    void Start()
    {
        detectionBallonScript = GameObject.Find("Zone Point").GetComponent<DetectionBallon>();
        mouseControlScript = GameObject.Find("GuideGameObject").GetComponent<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {
       if (mouseControlScript.startBallTimer == true)
        {
            if (detectionBallonScript.spawn == true)
            {
                Debug.Log("Spawn un ballon");
                fermeTimer = true;
                Invoke("spawnBallon", spawnInterval);
            }
            
        }
       
    }
    void spawnBallon()
    {
        //crée un nuage où l'avion était, à l'instant ou la fonction fût activer
        Instantiate(Ballon, transform.position, transform.rotation);
        

    }
}
