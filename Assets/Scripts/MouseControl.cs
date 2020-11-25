using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
	public Transform ObjectHolder;
	public float ThrowForce;
	public bool carryObject;
	public bool startBallTimer;
	public GameObject Item;
	public GameObject Ballon;
	public bool IsThrowable;
	private SpawnManager spawnManagerScript;
	private DetectionBallon detectionBallonScript;
	// Start is called before the first frame update
	void Start()
	{
		detectionBallonScript = GameObject.Find("Zone Point").GetComponent<DetectionBallon>();
		spawnManagerScript = GameObject.Find("spawnBallon").GetComponent<SpawnManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			
			RaycastHit hit;
			Ray directionRay = new Ray(transform.position, transform.forward);
			if (Physics.Raycast(directionRay, out hit, 10f))
			{
				if (hit.collider.tag == "Object")
				{
					carryObject = true;
					IsThrowable = true;
					spawnManagerScript.fermeTimer = false;
					if (carryObject == true)
					{
						Item = hit.collider.gameObject;
						Item.transform.SetParent(ObjectHolder);
						Item.gameObject.transform.position = ObjectHolder.position;
						Item.GetComponent<Rigidbody>().isKinematic = true;
						Item.GetComponent<Rigidbody>().useGravity = false;
						
					}
				}
			}
		}
		if (carryObject == false)
		{
			ObjectHolder.DetachChildren();
			Item.GetComponent<Rigidbody>().isKinematic = false;
			Item.GetComponent<Rigidbody>().useGravity = true;
			
		}
		if (Input.GetMouseButton(0))
		{	
			
		if (IsThrowable == true)
			{
				ObjectHolder.DetachChildren();
				Item.GetComponent<Rigidbody>().isKinematic = false;
				Item.GetComponent<Rigidbody>().useGravity = true;
				Item.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ThrowForce);
				startBallTimer = true;
	
			}
			IsThrowable = false;
			carryObject = false;
		}

		if (spawnManagerScript.fermeTimer == true)
        {
			Debug.Log("ferme le timer");
			startBallTimer = false;
			Item = null;
		}
	}

}