using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

//	public GameObject[] balls;

	public GameObject greenBall;
	public GameObject redBall;
	public GameObject greyBall;
	public GameObject brownBall;

	Animator greenBallAnim;
	Animator redBallAnim;
	Animator greyBallAnim;
	Animator brownBallAnim;

	int randomIndex = 0;

	void Awake()
	{
		greenBallAnim = greenBall.GetComponent<Animator> ();
		redBallAnim = redBall.GetComponent<Animator> ();
		greyBallAnim = greyBall.GetComponent<Animator> ();
		brownBallAnim = brownBall.GetComponent<Animator> ();

		greenBallAnim.enabled = false;
		redBallAnim.enabled = false;
		greyBallAnim.enabled = false;
		brownBallAnim.enabled = false;
	}

	void Start()
	{
		InvokeRepeating ("Twinkle", 1f, .5f);
	}

	void Twinkle()
	{
		randomIndex = Random.Range (0, 4);

		switch (randomIndex) {
		case 0:
			{
				greenBallAnim.enabled = true;
				redBallAnim.enabled = false;
//				greyBallAnim.enabled = false;
				brownBallAnim.enabled = false;
				break;
			}
		case 1:
			{
//				greenBallAnim.enabled = false;
				redBallAnim.enabled = true;
				greyBallAnim.enabled = false;
				brownBallAnim.enabled = false;
				break;
			}
		case 2:
			{
				greenBallAnim.enabled = false;
				redBallAnim.enabled = false;
				greyBallAnim.enabled = true;
//				brownBallAnim.enabled = false;
				break;
			}
		case 3:
			{
				greenBallAnim.enabled = false;
				redBallAnim.enabled = false;
//				greyBallAnim.enabled = false;
				brownBallAnim.enabled = true;
				break;
			}
		}
			
	}
}
