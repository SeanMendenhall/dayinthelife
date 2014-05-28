using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public GameObject enemy;
	private SpriteRenderer healthBar;
	private Vector3 healthScale;
	private float health;
	
	void Awake()
	{
		healthBar = GameObject.Find ("EnemyHealthRemaining").GetComponent<SpriteRenderer> ();
		
		healthScale = healthBar.transform.localScale;
		health = enemy.GetComponent<control_enemy> ().enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
		health = enemy.GetComponent<control_enemy> ().enemyHealth;
		healthBar.material.color = Color.Lerp (Color.red,Color.green,
		                                       health * 0.01f);
		
		healthBar.transform.localScale = new Vector3 (healthScale.x * 
		                                              health * 0.01f, 1, 1);
	}
}
