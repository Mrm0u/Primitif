using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public float TempsBallon = 5.0f;

    private MouseControl mouseControlScript;
    // Start is called before the first frame update
    void Start()
    {
        mouseControlScript = GameObject.Find("GuideGameObject").GetComponent<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseControlScript.startBallTimer == true)
        {

            Destroy(gameObject, TempsBallon);
        }
        
    }
}
