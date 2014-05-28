using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {
	public GameObject enemy;
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
			enemy.GetComponent<control_enemy>().enemyHealth -= 1f;
		}
	}
}
