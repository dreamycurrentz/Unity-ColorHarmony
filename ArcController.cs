using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcController : MonoBehaviour
{
	static float speed = 50f;
	int random;
	private GameController arcGameController;

	void Start ()
	{
		GameObject arcRotator = GameObject.FindGameObjectWithTag ("GameController");
		arcGameController = arcRotator.GetComponent<GameController> ();
	}

	void Update ()
	{
		//Less than 5
		if (arcGameController.score == 0) {
			speed = 30f;
			transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
		}
		else if(arcGameController.score == 1) {
			speed = 50f;
			transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
		}
		else if(arcGameController.score <= 2) {
			speed = 100f;
			transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));		
		} else if (arcGameController.score == 3) {
			speed = 100f;
			transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));	
		}else if (arcGameController.score <= 5) {
			speed = 100f;
			transform.Rotate (new Vector3 (0f, 0f, 1f * -speed * Time.deltaTime));	
		} else {
			int state = arcGameController.score % 10;
			switch (state) {
			case 0:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 1:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 2:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 3:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 4:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 5:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 6:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * -speed * Time.deltaTime));
				break;
			case 7:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 8:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * speed * Time.deltaTime));
				break;
			case 9:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * -speed * Time.deltaTime));
				break;
			case 10:
				speed = 100f;
				transform.Rotate (new Vector3 (0f, 0f, 1f * -speed * Time.deltaTime));
				break;
			}
		}
	
	}
}

