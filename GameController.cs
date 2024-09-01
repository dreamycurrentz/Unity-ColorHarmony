using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//Instance
	public static GameController instance = null;

	public GameObject gameControllerScript;
	public GameObject[] player;
	public Transform spawnPosition;

	public Text ScoreText;
	public int score = 0;

	public static float colorValue;
	public GameObject[] hintLines;

	[HideInInspector]
	public bool moveUpLine = false;
	[HideInInspector]
	public bool moveDownLine = false;
	[HideInInspector]
	public bool moveLeftLine = false;
	[HideInInspector]
	public bool moveRightLine = false;

	//Timer
	public Text timerText;
	public float startTime;
	//TimerEffect
	public GameObject timerPanel;

	private int i = 0;
	private string currentTime;

	void Awake(){
		SpawnPlayer ();
		timerPanel.SetActive (false);
	}

	void Update(){
		startTime = startTime - Time.deltaTime;
		currentTime = string.Format ("{0:0.00}", startTime);
		timerText.text = "" + currentTime;

		if (startTime <= 5) {
			timerPanel.SetActive (true);
		}

		if (startTime <= 0) {
//			GameOver ();
		}

		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}

	public void SpawnPlayer(){
//		ResetLines ();

		if (i == 0) {
			moveUpLine = true;
			moveDownLine = true;
			moveLeftLine = true;
			moveRightLine = true;
			i++;
		}

		int randomNo = Random.Range (0, 6);

		//Has to take out this command
//		colorValue = 0;

		switch (randomNo) {
		case 0:
			colorValue = 0;
			break;
		case 1:
			colorValue = 1;
			break;
		case 2:
			colorValue = 2;
			break;
		case 3:
			colorValue = 3;
			break;
		case 4:
			colorValue = 4;
			break;
		case 5:
			colorValue = 5;
			break;
		}

		Instantiate (player [randomNo], spawnPosition.position, Quaternion.identity);
//		Instantiate (player [0], spawnPosition.position, Quaternion.identity);
	}

	public void SetScore(){
		score += 1;

		if (score >= 1) {
			int randomIndex = Random.Range (0, hintLines.Length);
			for (int i = 0; i < hintLines.Length; i++) {
				if (i != randomIndex) {
					hintLines [i].SetActive (false);
				} else {
					hintLines [i].SetActive (true);
				}
			}
		}

		if (hintLines [0].activeSelf == true) {
			moveUpLine = true;
		}
		if (hintLines [1].activeSelf == true) {
			moveDownLine = true;
		}
		if (hintLines [2].activeSelf == true) {
			moveLeftLine = true;
		}
		if (hintLines [3].activeSelf == true) {
			moveRightLine = true;
		}

		ScoreText.text = "" + score;
	}

	public void GameOver()
	{
		GameObject playerObj = GameObject.FindGameObjectWithTag ("Player");
		print ("GameOver");
		Destroy (playerObj);
	}

	public void DestroyObject()
	{
		GameObject destroyPlayerObj = GameObject.FindGameObjectWithTag ("Player");
		Destroy (destroyPlayerObj);
	}

	public void ResetLines()
	{
		moveUpLine = false;
		moveDownLine = false;
		moveLeftLine = false;
		moveRightLine = false;
	}

	public bool CheckCondition()
	{
		GameObject playerManager = GameObject.FindGameObjectWithTag ("Player");
		PlayerMovement playerMovement = playerManager.GetComponent<PlayerMovement> ();

		if (moveUpLine == true && playerMovement.moveUp == true) {
			return true;
		} else if (moveDownLine == true && playerMovement.moveDown == true) {
			return true;
		} else if (moveLeftLine == true && playerMovement.moveLeft == true) {
			return true;
		} else if (moveRightLine == true && playerMovement.moveRight == true) {
			return true;
		}
//		print (moveUpLine);
//		print (playerMovement.moveUp);
		return false;
	}
}