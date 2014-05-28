using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
	public GameObject player;
	private SpriteRenderer healthBar;
	private Vector3 healthScale;
	private float health;

	void Awake()
	{
		healthBar = GameObject.Find ("HealthRemaining").GetComponent<SpriteRenderer> ();

		healthScale = healthBar.transform.localScale;
		health = player.GetComponent<control_player> ().playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		health = player.GetComponent<control_player> ().playerHealth;

		healthBar.material.color = Color.Lerp (Color.red,Color.green,
						health * 0.01f);

		healthBar.transform.localScale = new Vector3 (healthScale.x * 
						health * 0.01f, 1, 1);
	}
}
