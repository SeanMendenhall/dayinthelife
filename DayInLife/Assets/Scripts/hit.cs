using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// austin's comment
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Fist")
		{
			Destroy (gameObject);
		}
	}
}
