using UnityEngine;
using System.Collections;
using System.Timers;

public class control_game : MonoBehaviour {
	private float countdown = 4f;
	public GUIText countdownText;
	public GameObject player;
	public GameObject enemy;
	public bool beatEnemy = false;
	public GUIText winText;

	// Use this for initialization
	void Start () {
		countdownText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		// count down
		if(countdown > 0)
		{
			countdown -= Time.deltaTime;
			string countString = "";
			if(countdown > 3f)
				countString = "3";
			else if(countdown > 2f)
				countString = "2";
			else if(countdown > 1f)
				countString = "1";
			else if(countdown > 0f)
				countString = "GO!";
			countdownText.text = countString;
		}
		else
		{
			player.GetComponent<control_player>().gameStarted = true;
			countdownText.text = "";
		}
		if(enemy.GetComponent<control_enemy>().enemyHealth <= 0)
		{
			winText.text = "You win!";
			player.GetComponent<control_player>().gameStarted = false;
		}
		else
			winText.text = "";

	}


}
